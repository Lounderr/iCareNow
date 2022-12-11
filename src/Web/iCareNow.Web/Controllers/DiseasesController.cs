using Microsoft.AspNetCore.Mvc;

namespace iCareNow.Web.Controllers
{
    public class DiseasesController : BaseController
    {
        public DiseasesController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
