﻿using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
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
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IUnitService, UnitService>();
        }
    }
}
