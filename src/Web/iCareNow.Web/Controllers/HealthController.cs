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

        public IActionResult Index(SearchArticleInputModel searchModel)
        {
            var articles = this.articlesService.GetAllArticlesBySearch<ArticleInListViewModel>(searchModel);
            var viewModel = new ArticlesListViewModel
            {
                Articles = articles,
                ArticlesLetters = this.articlesService.GetAllSearchArticlesLetters(articles),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> HealthArticle(string id)
        {
            var viewModel = await this.articlesService.GetArticleByIdAsync<ArticleInputModel>(id);

            return this.View(viewModel);
        }
    }
}
