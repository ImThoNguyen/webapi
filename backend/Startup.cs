using backend.Data.Context;
using backend.Handler;
using backend.Queries;
using backend.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.CrossCuttingConcerns;
using backend.Extensions;

namespace backend
{
    public class AppSetting
    {
        public AWSConfig AWSConfig { get; set; }

    }

    public class AWSConfig
    {
        public string Name { get; set; }
    }
    public class Startup
    {
        public AppSetting AppSettings { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = new AppSetting();
            Configuration.Bind(AppSettings);
        }



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend", Version = "v1" });
            });
            services.AddValidatorBootstrapper();

            services.AddIdentityModuleCore(Configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            
            services.AddScoped<ISortNumberHandler, SortNumberHandler>();

            services.AddScoped<IRegistryUserHandler, RegistryUserHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseExceptionHandler(c => c.Run(async context =>
            //{
            //    var exception = context.Features
            //        .Get<IExceptionHandlerPathFeature>()
            //        .Error;
            //    var response = new { error = exception.Message };
            //    await context.Response.WriteAsJsonAsync(response);
            //}));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
