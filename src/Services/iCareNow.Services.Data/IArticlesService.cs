namespace iCareNow.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using iCareNow.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel inputModel);

        Task<T> GetArticleByIdAsync<T>(string id);

        Task UpdateAsync(string id, EditArticleInputModel input);

        Task<string> GetArticleKeywords(string articleId);

        Task DeleteAsync(string id);

        IEnumerable<SelectListItem> PopulateBioSystems();
    }
}
