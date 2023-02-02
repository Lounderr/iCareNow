namespace iCareNow.Data.Models
{
    public class ArticleKeyword
    {
        public int Id { get; set; }

        public string ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public int KeywordId { get; set; }

        public virtual Keyword Keyword { get; set; }
    }
}
