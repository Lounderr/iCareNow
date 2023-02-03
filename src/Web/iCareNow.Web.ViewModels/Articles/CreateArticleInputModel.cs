namespace iCareNow.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CreateArticleInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string BioSystem { get; set; }

        public IEnumerable<SelectListItem> BioSysytemItems { get; set; }

        public string Keywords { get; set; }
    }
}
