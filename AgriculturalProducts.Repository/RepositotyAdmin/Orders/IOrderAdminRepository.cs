using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IOrderAdminRepository:IBaseRepository<Order>
    {
        int GetStatisticsOrders();
    }
}
