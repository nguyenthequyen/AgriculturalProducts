using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class OrderAdminRepository : BaseRepository<Order>, IOrderAdminRepository
    {
        private static ApplicationContext _applicationContext;
        public OrderAdminRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public int GetStatisticsOrders()
        {
            return _applicationContext.Orders.Count();
        }
    }
}
