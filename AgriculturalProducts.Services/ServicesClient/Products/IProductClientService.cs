using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IProductClientService : IBaseService<Product>
    {
        List<object> GetTopNewPoduct();
        List<object> GetListDiscountProducts();
        List<object> GetProductDetails(Guid id);
        List<object> FindProductByName(string name);
        void UpdateProduct(List<ProductOrder> productOrders);
        List<object> GetProductByCategory(Guid id);
    }
}
