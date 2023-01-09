using Microsoft.AspNetCore.Mvc;

namespace iCareNow.Web.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
