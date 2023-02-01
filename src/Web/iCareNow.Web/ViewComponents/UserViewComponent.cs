using iCareNow.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.Threading.Tasks;

namespace iCareNow.Web.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserViewComponent(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke(string nameSize = "")
        {
            var user = this.userManager.GetUserAsync((ClaimsPrincipal)this.User).GetAwaiter().GetResult();

            if (nameSize == "full")
            {
                return this.Content($"{user.FirstName} {user.LastName}");
            }

            return this.Content(user.FirstName);
        }
    }
}
