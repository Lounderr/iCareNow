using iCareNow.Web.ViewModels;
using iCareNow.Web.ViewModels.Articles;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace iCareNow.Services.Data
{
    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel inputModel);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllArticlesBySearch<T>(SearchArticleInputModel searchModel);

        IEnumerable<ArticleLetter> GetAllSearchArticlesLetters(IEnumerable<ArticleInListViewModel> articles);

        Task<T> GetArticleByIdAsync<T>(string id);
    }
}
