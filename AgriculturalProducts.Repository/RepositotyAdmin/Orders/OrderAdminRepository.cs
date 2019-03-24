using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class OrderAdminRepository : BaseRepository<Order>, IOrderAdminRepository
    {
        private readonly ApplicationContext _applicationContext;
        public OrderAdminRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<object> GetAllOrders()
        {
            var order = _applicationContext.Orders
                .Join(_applicationContext.OrderDetails, od => od.Id, odt => odt.OrderId, (od, odt) => new { od, odt })
                .Select(o => new
                {
                    Quantity = o.odt.Quantity,
                    TotalCost = o.odt.TotalCost,
                    ProductName = _applicationContext.Products.Where(x => x.Id == o.odt.ProductId).Select(p => p.Name),
                    UserName = _applicationContext.Users.Where(x => x.Id == o.od.UserId).Select(x => x.LastName + x.FirstName),
                    StatusCart = _applicationContext.StatusCarts.Where(x => x.Id == o.od.StatusCartsId).Select(x => x.Name),
                    CreatedDate = o.od.CreatedDate
                }).ToList();
            List<object> orders = new List<object>();
            foreach (var item in order)
            {
                orders.Add(item);
            }
            return orders;
        }

        public int GetStatisticsOrders()
        {
            return _applicationContext.Orders.Count();
        }
    }
}
