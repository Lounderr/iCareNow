namespace iCareNow.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using iCareNow.Data.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class Article : BaseDeletableModel<string>
    {
        public Article()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Keywords = new HashSet<ArticleKeyword>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string BioSystem { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public virtual ICollection<ArticleKeyword> Keywords { get; set; }
    }
}
