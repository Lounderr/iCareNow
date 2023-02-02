namespace iCareNow.Web.Controllers
{
    using iCareNow.Services.Data;
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

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> HealthArticle(string id)
        {
            var article = await this.articlesService.GetArticleByIdAsync<ArticleInputModel>(id);

            return this.View(article);
        }
    }
}
