namespace iCareNow.Web.Controllers
{
    using iCareNow.Services.Data;
    using iCareNow.Web.ViewModels;
    using iCareNow.Web.ViewModels.Articles;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    public class HealthController : BaseController
    {
        private readonly IArticlesService articlesService;

        public HealthController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult Index(string search)
        {
            var articles = this.articlesService.GetAllArticlesBySearch<ArticleInListViewModel>(search);
            var viewModel = new ArticlesListViewModel
            {
                Articles = articles,
                ArticlesLetters = this.articlesService.GetAllSearchArticlesLetters(articles),
                BioSystems = this.articlesService.GetAllBioSystems(),
                Search = search,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> HealthArticle(string id)
        {
            var viewModel = await this.articlesService.GetArticleByIdAsync<ArticleInputModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
