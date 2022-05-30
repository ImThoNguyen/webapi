using backend.Queries;
using backend.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Extensions
{
    public static class ValidatorBootstrapper
    {
        public static IServiceCollection AddValidatorBootstrapper(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegistryUser>, RegistryUserValidator>();
            services.AddScoped<IValidator<GetStringNumber>, GetStringNumberValidator>();

            return services;
        }
    }
}
