namespace iCareNow.Services.Data
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using iCareNow.Data.Common.Repositories;
    using iCareNow.Data.Models;
    using iCareNow.Services.Mapping;
    using iCareNow.Web.ViewModels.Articles;
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

        public async Task UpdateAsync(string id, EditArticleInputModel input)
        {
            var article = await this.articlesRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            article.Title = input.Title;
            article.Content = input.Content;
            article.BioSystem = input.BioSystem;

            await this.keywordsService.RemoveAllKeywordsForArticleAsync(id);
            article.Keywords.Clear();

            var keywords = input.Keywords.Split(",").Select(x => x.Trim()).ToList();

            foreach (var keyword in keywords)
            {
                var keywordEntity = await this.keywordsService.CreateKeywordAsync(keyword);

                article.Keywords.Add(new ArticleKeyword
                {
                    Keyword = keywordEntity,
                });
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
    }
}
