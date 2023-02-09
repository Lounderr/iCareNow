// ReSharper disable VirtualMemberCallInConstructor
namespace iCareNow.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using iCareNow.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        [Required]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-ZA-Яа-я]+$")]
        [ProtectedPersonalData]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string NormalizedFirstName { get; set; }

        [Required]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-ZA-Яа-я]+$")]
        [ProtectedPersonalData]
        public string LastName { get; set; }

        [Required]
        [StringLength(80)]
        public string NormalizedLastName { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
