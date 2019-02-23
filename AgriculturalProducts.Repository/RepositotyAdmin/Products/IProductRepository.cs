using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void InsertProduct(Product provider);
        void UpdateProduct(Product provider);
        IEnumerable<Product> GetAllProduct();
        void DeleteProduct(Product provider);
        Task<Product> FindProductById(Guid id);
        int ProductStatistics();
    }
}
