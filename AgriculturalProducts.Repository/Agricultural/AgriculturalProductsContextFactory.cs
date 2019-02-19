using AgriculturalProducts.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class AgriculturalProductsContextFactory : DesignTimeDbContextFactoryBase<AgriculturalProductsContext>
    {
        protected override AgriculturalProductsContext CreateNewInstance(DbContextOptions<AgriculturalProductsContext> options)
        {
            return new AgriculturalProductsContext(options);
        }
    }
}
