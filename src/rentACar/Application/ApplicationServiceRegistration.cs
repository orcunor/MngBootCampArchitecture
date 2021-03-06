using Application.Features.Brands.Rules;
using Application.Features.Models.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
             
            services.AddScoped<BrandBusinessRules>(); // bellekte tutma sadece injection yap bırak demek
            services.AddScoped<ModelBusinessRules>();

            return services;
        }
    }
}
