namespace iCareNow.Web.ViewModels.Articles
{
    using iCareNow.Data.Models;
    using iCareNow.Services.Mapping;

    public class ArticleInListViewModel : IMapFrom<Article>
    {
        public string Id { get; set; }

        public string Title { get; set; }
    }
}
