namespace iCareNow.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Keywords { get; set; }
    }
}
