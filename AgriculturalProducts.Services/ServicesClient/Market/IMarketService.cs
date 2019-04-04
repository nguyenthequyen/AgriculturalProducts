using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IMarketService:IBaseService<Product>
    {
        PageList<Product> GetMarketPageList(PagingParams pagingParams);
    }
}
