using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IProductClientRepository : IBaseRepository<Product>
    {
        List<object> GetTopNewPoduct();
        List<object> GetListDiscountProducts();
        List<object> GetProductDetails(Guid id);
    }
}
