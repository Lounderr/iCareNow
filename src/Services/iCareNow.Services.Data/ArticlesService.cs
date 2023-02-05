namespace iCareNow.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using iCareNow.Data.Common.Repositories;
    using iCareNow.Data.Models;
    using iCareNow.Services.Mapping;
    using iCareNow.Web.ViewModels;
    using iCareNow.Web.ViewModels.Articles;

    using Microsoft.EntityFrameworkCore;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;
        private readonly IKeywordsService keywordsService;

        public ArticlesService(
            IDeletableEntityRepository<Article> articlesRepository,
            IKeywordsService keywordsService)
        {
            this.articlesRepository = articlesRepository;
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

            var keywords = inputModel.Keywords.Split(",").Select(x => x.Trim()).ToList();

            foreach (var keyword in keywords)
            {
                var keywordEntity = await this.keywordsService.CreateKeywordAsync(keyword);

                article.Keywords.Add(new ArticleKeyword
                {
                    Keyword = keywordEntity,
                });
            }

            await this.articlesRepository.AddAsync(article);
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

        public IEnumerable<T> GetAllArticlesBySearch<T>(SearchArticleInputModel searchModel)
        {
            var query = this.articlesRepository.All().AsQueryable();

            if (searchModel?.Search != null)
            {
                query = query.Where(x => x.Title.Contains(searchModel.Search) || x.Keywords.Any(x => x.Keyword.Value.Contains(searchModel.Search)));
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

        public Task<T> GetArticleByIdAsync<T>(string id)
        {
            return this.articlesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
        }
    }
}
