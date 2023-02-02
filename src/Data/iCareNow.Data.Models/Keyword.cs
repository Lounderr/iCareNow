namespace iCareNow.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using iCareNow.Data.Common.Models;

    public class Keyword : BaseDeletableModel<int>
    {
        public Keyword()
        {
            this.Articles = new HashSet<ArticleKeyword>();
        }

        [Required]
        public string Value { get; set; }

        public virtual ICollection<ArticleKeyword> Articles { get; set; }
    }
}
