using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Permission : Entity<Guid>
    {
        [MaxLength(300)]
        public string PermissionName { get; set; }
        public virtual User Users { get; set; }
    }
}
