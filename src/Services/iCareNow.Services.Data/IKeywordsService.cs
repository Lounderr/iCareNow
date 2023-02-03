namespace iCareNow.Services.Data
{
    using iCareNow.Data.Models;

    using System.Threading.Tasks;

    public interface IKeywordsService
    {
        Task<Keyword> CreateKeywordAsync(string keyword);

        Task RemoveAllKeywordsForArticleAsync(string articleId);
    }
}
