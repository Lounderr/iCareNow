using iCareNow.Web.ViewModels.Articles;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace iCareNow.Services.Data
{
    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel inputModel);

        IEnumerable<T> GetAll<T>();

        IEnumerable<ArticleLetter> GetAllArticlesLetters();

        Task<T> GetArticleByIdAsync<T>(string id);
    }
}
