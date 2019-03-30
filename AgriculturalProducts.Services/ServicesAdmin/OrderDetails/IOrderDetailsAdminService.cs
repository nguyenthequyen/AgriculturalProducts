using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IOrderDetailsAdminService : IBaseService<OrderDetails>
    {
        Task<OrderDetails> GetOrderDetailsById(Guid id);
    }
}
