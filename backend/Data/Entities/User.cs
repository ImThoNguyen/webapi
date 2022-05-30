using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class User : Entity<Guid>
    {
        [MaxLength(100)]
        public string AccountName { get; set; }
        [MaxLength(1024)]
        public string Password { get; set; }
        public string CommonName { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }
        public string UserNote { get; set; }
        public bool? ExternalUser { get; set; }
        public string Photo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool? Active { get; set; }
        public string UserInfo { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual List<Permission> Permissions { get; set; }

    }
}
