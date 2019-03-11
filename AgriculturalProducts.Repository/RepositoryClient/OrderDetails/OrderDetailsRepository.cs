using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationContext _applicationContext;
        public OrderDetailsRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            Add(orderDetails);
        }
    }
}
