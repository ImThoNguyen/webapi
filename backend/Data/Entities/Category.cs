using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Category : Entity<Guid>
    {
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string MetaTitle { get; set; }
        [MaxLength(200)]
        public string Slug { get; set; }
        [MaxLength(int.MaxValue)]
        public string Content { get; set; }
        public virtual List<Post> Posts { get; set; } 
    }
}
