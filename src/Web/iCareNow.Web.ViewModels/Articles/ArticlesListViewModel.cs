namespace iCareNow.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class ArticlesListViewModel
    {
        public IEnumerable<ArticleInListViewModel> Articles { get; set; }

        public IEnumerable<ArticleLetter> ArticlesLetters { get; set; }
    }
}
