namespace iCareNow.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;
    using System.Net;

    using AutoMapper;
    using iCareNow.Data.Models;
    using iCareNow.Services.Mapping;

    public class EditArticleInputModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string BioSystem { get; set; }

        public string Keywords { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, EditArticleInputModel>()
            .ForMember(x => x.Content, opt =>
                    opt.MapFrom(x => WebUtility.HtmlDecode(x.Content)));
        }
    }
}
