using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void InsertProduct(Product product);
    }
}
