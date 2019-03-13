using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IOrderDetailsService : IBaseService<OrderDetails>
    {
        void AddOrderDetails(OrderDetails orderDetails);
    }
}
