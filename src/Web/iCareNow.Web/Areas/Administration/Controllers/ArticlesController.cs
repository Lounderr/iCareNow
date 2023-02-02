using iCareNow.Common;
using iCareNow.Services.Data;
using iCareNow.Web.ViewModels.Articles;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iCareNow.Web.Areas.Administration.Controllers
{
    public class ArticlesController : AdministrationController
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            await this.articlesService.CreateAsync(input);

            return this.RedirectToAction("Index", "Dashboard", new { area = "Administration" });
        }
    }
}
