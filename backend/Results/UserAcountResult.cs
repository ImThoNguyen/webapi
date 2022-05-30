using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results
{
    public class UserAcountResult
    {
        public string AccountName { get; set; }
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
    }
}
