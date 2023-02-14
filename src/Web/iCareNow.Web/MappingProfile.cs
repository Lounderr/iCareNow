namespace iCareNow.Web
{
    using AutoMapper;
    using iCareNow.Data.Models;
    using iCareNow.Web.ViewModels.Articles;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ArticleInListViewModel, Article>();

            this.CreateMap<ArticleInputModel, Article>();

            this.CreateMap<EditArticleInputModel, Article>();

            this.CreateMap<Article, ArticleInputModel>();


            this.CreateMap<Article, CreateArticleInputModel>();
        }
    }
}
