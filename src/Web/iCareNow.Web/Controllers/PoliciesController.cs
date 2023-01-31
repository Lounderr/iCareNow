using Microsoft.AspNetCore.Mvc;

namespace iCareNow.Web.Controllers
{
    public class PoliciesController : BaseController
    {
        public IActionResult Tos()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }
    }
}
