namespace iCareNow.Web.Controllers
{
    using iCareNow.Services.Data;
    using iCareNow.Web.ViewModels.Articles;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class FiltersController : BaseController
    {
        private readonly IArticlesService articlesService;

        public FiltersController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [HttpPost]
        public IActionResult Post(PostArticlesFilterInputModel input)
        {
            var articles = this.articlesService.GetAllArticlesBasedOnBioSystems<ArticleInListViewModel>(input.ArticlesIds, input.BioSystemsToFilter);
            var viewModel = new ArticlesListViewModel
            {
                Articles = articles,
                ArticlesLetters = this.articlesService.GetAllSearchArticlesLetters(articles),
            };

            return this.PartialView("~/Views/Health/_ArticleListPartial.cshtml", viewModel);
        }
    }
}
