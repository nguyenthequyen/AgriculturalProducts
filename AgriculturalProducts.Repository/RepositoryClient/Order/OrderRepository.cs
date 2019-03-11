using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRpository
    {
        private readonly ApplicationContext _applicationContext;
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void AddOrder(Order order)
        {
            Add(order);
        }
    }
}
