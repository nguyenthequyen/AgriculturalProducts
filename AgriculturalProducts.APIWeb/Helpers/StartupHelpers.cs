﻿using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AgriculturalProducts.APIWeb.Helpers
{
    public static class StartupHelpers
    {
        public static void RegisterServiceAndRespository(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            //Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Repository
            services.AddScoped<IProductClientRepository, ProductClientRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IImagesClientRepository, ImagesClientRepository>();
            services.AddScoped<IUserClientRepository, UserClientRepository>();
            services.AddScoped<IOrderRpository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            
            //Services
            services.AddScoped<IProductClientService, ProductClientService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IImagesClientServices, ImagesClientServices>();
            services.AddScoped<IUserClientService, UserClientService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
        }
    }
}
