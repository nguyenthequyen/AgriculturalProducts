using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IProductClientService : IBlogsService<Product>
    {
        List<object> GetTopNewPoduct();
        List<object> GetListDiscountProducts();
        List<object> GetProductDetails(Guid id);
    }
}
