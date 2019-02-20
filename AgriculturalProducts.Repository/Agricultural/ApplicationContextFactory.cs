using AgriculturalProducts.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class ApplicationContextFactory : DesignTimeDbContextFactoryBase<ApplicationContext>
    {
        protected override ApplicationContext CreateNewInstance(DbContextOptions<ApplicationContext> options)
        {
            return new ApplicationContext(options);
        }
    }
}
