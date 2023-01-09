namespace iCareNow.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HealthAtoZController : BaseController
    {
        public HealthAtoZController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult HealthArticle()
        {
            return this.View();
        }
    }
}
