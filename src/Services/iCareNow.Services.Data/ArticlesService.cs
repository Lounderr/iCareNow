namespace iCareNow.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Threading.Tasks;

    using iCareNow.Data.Common.Repositories;
    using iCareNow.Data.Models;
    using iCareNow.Services.Mapping;
    using iCareNow.Web.ViewModels;
    using iCareNow.Web.ViewModels.Articles;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;
        private readonly IRepository<ArticleKeyword> articleKeywordRepository;
        private readonly IKeywordsService keywordsService;

        public ArticlesService(
            IDeletableEntityRepository<Article> articlesRepository,
            IRepository<ArticleKeyword> articleKeywordRepository,
            IKeywordsService keywordsService)
        {
            this.articlesRepository = articlesRepository;
            this.articleKeywordRepository = articleKeywordRepository;
            this.keywordsService = keywordsService;
        }

        public async Task CreateAsync(CreateArticleInputModel inputModel)
        {
            var article = new Article
            {
                Title = inputModel.Title,
                Content = WebUtility.HtmlEncode(inputModel.Content),
                BioSystem = inputModel.BioSystem,
            };

            await this.articlesRepository.AddAsync(article);

            var keywords = inputModel.Keywords.Split(",").Select(x => x.Trim()).ToList();

            foreach (var keyword in keywords)
            {
                var keywordEntity = await this.keywordsService.CreateKeywordAsync(keyword);

                var articleKeyword = new ArticleKeyword
                {
                    Article = article,
                    Keyword = keywordEntity,
                };

                await this.articleKeywordRepository.AddAsync(articleKeyword);
            }

            await this.articlesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.articlesRepository.AllAsNoTracking()
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllArticlesBasedOnBioSystems<T>(string[] articlesIds, string[] bioSystems)
        {
            var query = this.articlesRepository
                .AllAsNoTracking()
                .Where(x => articlesIds.Contains(x.Id))
                .AsQueryable();

            if (bioSystems.Length != 0)
            {
                query = query.Where(x => bioSystems.Contains(x.BioSystem));
            }

            var articles = query
                 .To<T>()
                 .ToList();

            return articles;
        }

        public IEnumerable<T> GetAllArticlesBySearch<T>(string search)
        {
            var query = this.articlesRepository.All().AsQueryable();

            if (search != null)
            {
                query = query.Where(x => x.Title.Contains(search) || x.Keywords.Any(x => x.Keyword.Value.Contains(search)));
            }

            var articles = query
                .To<T>()
                .ToList();

            return articles;
        }

        public IEnumerable<ArticleLetter> GetAllSearchArticlesLetters(IEnumerable<ArticleInListViewModel> articles)
        {
            var articleLetters = new List<ArticleLetter>();

            var letters = articles
                .Select(x => x.Title.FirstOrDefault())
                .Distinct()
                .ToList();

            foreach (var letter in letters)
            {
                var articleLetter = new ArticleLetter
                {
                    Letter = letter,
                    LetterSearchId = (int)letter - 1039,
                };

                articleLetters.Add(articleLetter);
            }

            return articleLetters.OrderBy(x => x.Letter);
        }

        public async Task UpdateAsync(string id, EditArticleInputModel input)
        {
            var article = await this.articlesRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            article.Title = input.Title;
            article.Content = WebUtility.HtmlEncode(input.Content);
            article.BioSystem = input.BioSystem;

            await this.keywordsService.RemoveAllKeywordsForArticleAsync(id);
            article.Keywords.Clear();

            var keywords = input.Keywords.Split(",").Select(x => x.Trim()).ToList();

            foreach (var keyword in keywords)
            {
                var keywordEntity = await this.keywordsService.CreateKeywordAsync(keyword);

                var articleKeyword = new ArticleKeyword
                {
                    Article = article,
                    Keyword = keywordEntity,
                };

                await this.articleKeywordRepository.AddAsync(articleKeyword);
            }

            await this.articlesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var article = await this.articlesRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            this.articlesRepository.Delete(article);
            await this.articlesRepository.SaveChangesAsync();
        }

        public Task<T> GetArticleByIdAsync<T>(string id)
        {
            return this.articlesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
        }

        public async Task<string> GetArticleKeywords(string articleId)
        {
            var keywords = await this.articleKeywordRepository.AllAsNoTracking()
                .Where(x => x.ArticleId == articleId)
                .Select(x => x.Keyword.Value)
                .ToListAsync();

            return string.Join(", ", keywords);
        }

        public IEnumerable<string> GetAllBioSystems()
        {
            return typeof(BioSystem).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string))
                .Select(x => (string)x.GetValue(null))
                .ToList();
        }

        public IEnumerable<SelectListItem> PopulateBioSystems()
        {
            var systems = typeof(BioSystem).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string))
                .ToDictionary(
                    x => x.Name,
                    y => (string)y.GetValue(null))
                .Select(x => new SelectListItem(x.Value, x.Value));

            return systems;
        }
    }
}
