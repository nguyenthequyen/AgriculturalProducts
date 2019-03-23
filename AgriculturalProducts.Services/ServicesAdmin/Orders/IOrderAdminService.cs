using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IOrderAdminService:IBaseService<Order>
    {
        int GetStatisticsOrder();
        PageList<object> GetOrderPagingnate(PagingParams pagingParams);
    }
}
