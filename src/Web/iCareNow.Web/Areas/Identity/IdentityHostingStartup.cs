using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(iCareNow.Web.Areas.Identity.IdentityHostingStartup))]
namespace iCareNow.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}