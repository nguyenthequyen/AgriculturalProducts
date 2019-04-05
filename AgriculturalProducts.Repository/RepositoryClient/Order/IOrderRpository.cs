using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IOrderRpository : IBaseRepository<Order>
    {
        void AddOrder(Order order);
        List<object> GetListOrder(Guid id);
    }
}
