namespace iCareNow.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using iCareNow.Web.ViewModels;

    public class ArticlesListViewModel
    {
        public IEnumerable<ArticleInListViewModel> Articles { get; set; }

        public SearchArticleInputModel SearchModel { get; set; }

        public IEnumerable<ArticleLetter> ArticlesLetters { get; set; }

        public IEnumerable<string> BioSystems { get; set; }
    }
}
