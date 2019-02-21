using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IProductService : IBaseService<Product>
    {
        void InsertProduct(Product product);
    }
}
