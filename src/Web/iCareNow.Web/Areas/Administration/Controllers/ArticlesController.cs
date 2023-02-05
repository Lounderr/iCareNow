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
            var viewModel = new CreateArticleInputModel();

            viewModel.BioSysytemItems = this.articlesService.PopulateBioSystems();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BioSysytemItems = this.articlesService.PopulateBioSystems();
                return this.View(input);
            }

            await this.articlesService.CreateAsync(input);

            return this.RedirectToAction("Index", "Health", new { area = "" });
        }

        public async Task<IActionResult> Edit(string id)
        {
            var input = await this.articlesService.GetArticleByIdAsync<EditArticleInputModel>(id);
            if (input == null)
            {
                return this.NotFound();
            }

            input.Keywords = await this.articlesService.GetArticleKeywords(id);
            input.BioSysytemItems = this.articlesService.PopulateBioSystems();

            return this.View(input);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Keywords = await this.articlesService.GetArticleKeywords(id);
                input.BioSysytemItems = this.articlesService.PopulateBioSystems();

                return this.View(input);
            }

            await this.articlesService.UpdateAsync(id, input);

            return this.RedirectToAction("HealthArticle", "Health", new { id, area = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.articlesService.DeleteAsync(id);
            return this.RedirectToAction("Index", "Health", new { area = "" });
        }
    }
}
