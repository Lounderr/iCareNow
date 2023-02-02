namespace iCareNow.Web.ViewModels.Articles
{
    using System.Net;

    using AutoMapper;
    using iCareNow.Data.Models;
    using iCareNow.Services.Mapping;

    public class ArticleInputModel : IHaveCustomMappings
    {
        public string Content { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, ArticleInputModel>()
            .ForMember(x => x.Content, opt =>
                    opt.MapFrom(x => WebUtility.HtmlDecode(x.Content)));
        }
    }
}
