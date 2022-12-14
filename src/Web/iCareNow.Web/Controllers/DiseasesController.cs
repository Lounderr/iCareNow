namespace iCareNow.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DiseasesController : BaseController
    {
        public DiseasesController()
        {
        }

        public IActionResult HealthAtoZ()
        {
            return this.View();
        }

        public IActionResult HealthArticle()
        {
            return this.View();
        }
    }
}
