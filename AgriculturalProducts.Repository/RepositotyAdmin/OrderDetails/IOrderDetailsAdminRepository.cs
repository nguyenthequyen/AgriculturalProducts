using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IOrderDetailsAdminRepository : IBaseRepository<OrderDetails>
    {
        Task<OrderDetails> GetOrderDetailsById(Guid id);
    }
}
