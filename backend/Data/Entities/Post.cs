using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Post : Entity<Guid>
    {
        [MaxLength(150)]
        public string Author { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string MetaTile { get; set; }
        [MaxLength(200)]
        public string  Slug { get; set; }
        public bool Published { get; set; }
        [MaxLength(int.MaxValue)]
        public string Content { get; set; }
        public virtual Category Category { get; set; }
    }
}
