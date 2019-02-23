using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IProductService : IBaseService<Product>
    {
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        IEnumerable<Product> GetAllProduct();
        void DeleteProduct(Product productType);
        Task<Product> FindProductById(Guid id);
        int ProductStatistics();
    }
}
