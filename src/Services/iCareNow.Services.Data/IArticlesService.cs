using iCareNow.Web.ViewModels.Articles;

using System.Threading.Tasks;

namespace iCareNow.Services.Data
{
    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel inputModel);

        Task<T> GetArticleByIdAsync<T>(string id);

        Task UpdateAsync(string id, EditArticleInputModel input);

        Task<string> GetArticleKeywords(string articleId);

        Task DeleteAsync(string id);
    }
}
