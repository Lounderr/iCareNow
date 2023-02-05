namespace iCareNow.Web.ViewModels.Articles
{
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;

    using AutoMapper;
    using iCareNow.Data.Models;
    using iCareNow.Services.Mapping;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EditArticleInputModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string BioSystem { get; set; }

        public IEnumerable<SelectListItem> BioSysytemItems { get; set; }

        public string Keywords { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, EditArticleInputModel>()
            .ForMember(x => x.Content, opt =>
                    opt.MapFrom(x => WebUtility.HtmlDecode(x.Content)));
        }
    }
}
