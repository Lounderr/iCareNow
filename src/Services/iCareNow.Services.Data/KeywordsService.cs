namespace iCareNow.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using iCareNow.Data.Common.Repositories;
    using iCareNow.Data.Models;

    public class KeywordsService : IKeywordsService
    {
        private readonly IDeletableEntityRepository<Keyword> keywordsRepository;
        private readonly IRepository<ArticleKeyword> articleKeywordRepository;

        public KeywordsService(
            IDeletableEntityRepository<Keyword> keywordsRepository,
            IRepository<ArticleKeyword> articleKeywordRepository)
        {
            this.keywordsRepository = keywordsRepository;
            this.articleKeywordRepository = articleKeywordRepository;
        }

        public async Task<Keyword> CreateKeywordAsync(string keyword)
        {
            var keywordEntity = this.keywordsRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Value == keyword);

            if (keywordEntity != null)
            {
                return keywordEntity;
            }

            keywordEntity = new Keyword
            {
                Value = keyword,
            };

            await this.keywordsRepository.AddAsync(keywordEntity);
            await this.keywordsRepository.SaveChangesAsync();

            return keywordEntity;
        }

        public async Task RemoveAllKeywordsForArticleAsync(string articleId)
        {
            var articleKeywords = this.articleKeywordRepository.All().Where(x => x.ArticleId == articleId);
            foreach (var articleKeyword in articleKeywords)
            {
                this.articleKeywordRepository.Delete(articleKeyword);
            }

            await this.articleKeywordRepository.SaveChangesAsync();
        }
    }
}
