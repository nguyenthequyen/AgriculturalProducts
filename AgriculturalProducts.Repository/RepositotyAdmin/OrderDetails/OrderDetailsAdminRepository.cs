using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class OrderDetailsAdminRepository : BaseRepository<OrderDetails>, IOrderDetailsAdminRepository
    {
        private readonly ApplicationContext _applicationContext;
        public OrderDetailsAdminRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<OrderDetails> GetOrderDetailsById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }
    }
}
