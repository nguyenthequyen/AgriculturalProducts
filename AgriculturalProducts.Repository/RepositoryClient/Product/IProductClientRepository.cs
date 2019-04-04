using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IProductClientRepository : IBaseRepository<Product>
    {
        List<object> GetTopNewPoduct();
        List<object> GetListDiscountProducts();
        List<object> GetProductDetails(Guid id);
        List<object> FindProductByName(string name);
        void UpdateProduct(Guid id, int quantity);
        List<object> GetProductByCategory(Guid id);
    }
}
