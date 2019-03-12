using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
            services.RegisterRepository();
            services.RegisterService();
        }
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            //Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IStatusProviderRepository, StatusProviderRepository>();
            services.AddScoped<IStatusProductRepository, StatusProductRepository>();
            services.AddScoped<IImagesRepository, ImagesRepository>();
            services.AddScoped<IUserAdminRepository, UserAdminRepository>();
            services.AddScoped<IUserClientRepository, UserClientRepository>();
        }
        public static void RegisterService(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IStatusProviderService, StatusProviderService>();
            services.AddScoped<IStatusProductService, StatusProductService>();
            services.AddScoped<IImagesService, ImagesService>();
            services.AddScoped<IUserAdminService, UserAdminService>();
            services.AddScoped<IUserClientService, UserClientService>();
            services.AddScoped<IBlogsService, BlogService>();
            services.AddMetaWeblog<MetaWeblogService>();
        }
    }
}
