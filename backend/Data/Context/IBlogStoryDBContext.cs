using backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Context
{
    public interface IBlogStoryDBContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<Gender> Genders { get; set; }
    }
}
