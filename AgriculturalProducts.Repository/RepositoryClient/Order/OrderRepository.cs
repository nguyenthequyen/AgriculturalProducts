using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<object> GetListOrder(Guid id)
        {
            var data = _applicationContext.Orders.Where(x => x.UserId == id)
                .Join(_applicationContext.OrderDetails, o => o.Id, od => od.OrderId, (o, od) => new { o, od })
                .Join(_applicationContext.Products, p => p.od.ProductId, pd => pd.Id, (p, pd) => new { p, pd })
                .Join(_applicationContext.StatusCarts, st => st.p.od.StatusCartId, sc => sc.Id, (st, sc) => new { st, sc })
                .Select(s => new
                {
                    ProductName = s.st.pd.Name,
                    Quantity = s.st.p.od.Quantity,
                    TotalCost = s.st.p.od.TotalCost,
                    StatusOrder = s.sc.Name,
                    Images = _applicationContext.Images.Where(x => x.ProductId == s.st.pd.Id).Select(
                        im => "data:image/png;base64, " + ConvertBase64.GetBase64StringForImage(im.Path)
                    ).ToList()
                });
            List<object> list = new List<object>();
            foreach (var item in data)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
