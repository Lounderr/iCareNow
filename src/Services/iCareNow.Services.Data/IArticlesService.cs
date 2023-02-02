using iCareNow.Web.ViewModels.Articles;

using System.Threading.Tasks;

namespace iCareNow.Services.Data
{
    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel inputModel);

        Task<T> GetArticleByIdAsync<T>(string id);
    }
}
