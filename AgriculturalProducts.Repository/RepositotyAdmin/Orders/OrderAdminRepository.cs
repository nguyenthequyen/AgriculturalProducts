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
            var order = _applicationContext.OrderDetails
                .Join(_applicationContext.Orders, od => od.OrderId, odt => odt.Id, (od, odt) => new { od, odt })
                .Join(_applicationContext.Products, pr => pr.od.ProductId, prt => prt.Id, (pr, prt) => new { pr, prt })
                .Join(_applicationContext.StatusCarts, st => st.pr.odt.StatusCartsId, stc => stc.Id, (st, stc) => new { st, stc })
                .Join(_applicationContext.Users, u => u.st.pr.odt.UserId, us => us.Id, (u, us) => new { u, us })
                .Select(
                           al => new
                           {
                               ProductName = al.u.st.prt.Name,
                               UserName = al.us.FirstName + al.us.LastName
                           }
                       ).ToList();
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
