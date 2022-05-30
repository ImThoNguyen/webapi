using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Gender : Entity<Guid>
    {
        public string GenderName { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
