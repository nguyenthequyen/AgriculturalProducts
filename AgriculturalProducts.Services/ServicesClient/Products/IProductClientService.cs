using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IProductClientService : IBaseService<Product>
    {
        List<object> GetTopNewPoduct();
    }
}
