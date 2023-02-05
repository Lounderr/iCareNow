namespace iCareNow.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
  
    using iCareNow.Web.ViewModels;
    using iCareNow.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel inputModel);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllArticlesBySearch<T>(SearchArticleInputModel searchModel);

        IEnumerable<ArticleLetter> GetAllSearchArticlesLetters(IEnumerable<ArticleInListViewModel> articles);

        Task<T> GetArticleByIdAsync<T>(string id);

        IEnumerable<T> GetAllArticlesBasedOnBioSystems<T>(string[] articlesIds, string[] bioSystems);

        Task UpdateAsync(string id, EditArticleInputModel input);

        Task<string> GetArticleKeywords(string articleId);

        Task DeleteAsync(string id);

        IEnumerable<SelectListItem> PopulateBioSystems();

        IEnumerable<string> GetAllBioSystems();
    }
}
