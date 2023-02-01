namespace iCareNow.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using iCareNow.Data.Models;
    using iCareNow.Web.ViewModels;
    using iCareNow.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View("NotFound");
            }

            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
