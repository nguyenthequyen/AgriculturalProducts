using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        void AddOrder(Order order);
    }
}
