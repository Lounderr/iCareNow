namespace iCareNow.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using iCareNow.Data.Common.Repositories;
    using iCareNow.Data.Models;

    public class KeywordsService : IKeywordsService
    {
        private readonly IDeletableEntityRepository<Keyword> keywordsRepository;

        public KeywordsService(IDeletableEntityRepository<Keyword> keywordsRepository)
        {
            this.keywordsRepository = keywordsRepository;
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

            var newKeywordEntity = new Keyword
            {
                Value = keyword,
            };

            await this.keywordsRepository.AddAsync(newKeywordEntity);
            await this.keywordsRepository.SaveChangesAsync();

            return newKeywordEntity;
        }
    }
}
