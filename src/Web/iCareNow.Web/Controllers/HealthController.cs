namespace iCareNow.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HealthController : BaseController
    {
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
