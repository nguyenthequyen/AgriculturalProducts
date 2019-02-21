using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProducts.APIWeb.Helpers
{
    public static class StartupHelpers
    {
        public static void RegisterServiceAndRespository(this IServiceCollection services)
        {
            //Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProviderService, ProviderService>();
        }
    }
}
