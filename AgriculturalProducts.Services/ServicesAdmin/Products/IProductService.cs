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
        void InsertProduct(List<Product> product);
        void UpdateProduct(List<Product> product);
        IEnumerable<Product> GetAllProduct();
        void DeleteProduct(List<Product> product);
        Task<Product> FindProductById(Guid id);
        int ProductStatistics();
        PageList<Product> GetProductPageList(PagingParams pagingParams);
    }
}
