namespace iCareNow.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using iCareNow.Data.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class Article : BaseDeletableModel<string>
    {
        public Article()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
