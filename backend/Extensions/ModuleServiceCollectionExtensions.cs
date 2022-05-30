using backend.Data.Context;
using backend.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Extensions
{
    public static class ModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityModuleCore(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<EFCoreDBContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("TESTAPIDB")));
            
            //services.AddDbContext<EFCoreDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TESTAPIDB"),
            //    b => b.MigrationsAssembly("Blogs.WebAPI")));

            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));

            services.AddScoped(typeof(IPostRepository), typeof(PostRepository));

            services.AddScoped(typeof(IUserReponsitory), typeof(UserReponsitory));

            services.AddScoped(typeof(IPermissionReponsitory), typeof(PermissionReponsitory));


            return services;
        }
    }
}
