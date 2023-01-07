using Microsoft.AspNetCore.Mvc;

namespace iCareNow.Web.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
