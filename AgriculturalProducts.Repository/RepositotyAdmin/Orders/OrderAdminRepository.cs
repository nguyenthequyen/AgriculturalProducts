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
                .Join(_applicationContext.UserInfors, od => od.UserId, us => us.UserId, (od, us) => new { od, us })
                .Join(_applicationContext.Users, od => od.od.UserId, us => us.Id, (od, us) => new { od, us })
                .Select(sl => new
                {
                    Custommer = sl.us.LastName + sl.us.FirstName,
                    TotalQuantity = sl.od.od.TotalQuantity,
                    TotalCost = sl.od.od.TotalCost,
                    Processor = sl.od.od.Processed,
                    Address = sl.od.us.Address,
                    Email = sl.us.Email,
                    Created = sl.od.od.CreatedDate,
                    Id = sl.od.od.Id
                });
            List<object> orders = new List<object>();
            foreach (var item in order)
            {
                orders.Add(item);
            }
            return orders;
        }

        public List<object> GetAllOrdersSearch(string name)
        {
            var order = _applicationContext.Orders
                .Join(_applicationContext.UserInfors, od => od.UserId, us => us.UserId, (od, us) => new { od, us })
                .Join(_applicationContext.Users, od => od.od.UserId, us => us.Id, (od, us) => new { od, us })
                .Where(x => (x.us.LastName + " " + x.us.FirstName).StartsWith(name) || x.us.Email.StartsWith(name))
                .Select(sl => new
                {
                    Custommer = sl.us.LastName + sl.us.FirstName,
                    TotalQuantity = sl.od.od.TotalQuantity,
                    TotalCost = sl.od.od.TotalCost,
                    Processed = sl.od.od.Processed,
                    Address = sl.od.us.Address,
                    Email = sl.us.Email,
                    CreatedDate = sl.od.od.CreatedDate
                });
            List<object> orders = new List<object>();
            foreach (var item in order)
            {
                orders.Add(item);
            }
            return orders;
        }
        public List<object> GetAllOrdersDetails(Guid id)
        {
            var orderdetails = _applicationContext.OrderDetails.Where(x => x.OrderId == id)
                .Join(_applicationContext.Products, od => od.ProductId, p => p.Id, (od, p) => new { od, p })
                .Join(_applicationContext.StatusCarts, sc => sc.od.StatusCartId, sct => sct.Id, (sc, sct) => new { sc, sct })
                .Select(rs => new
                {
                    ProductName = rs.sc.p.Name,
                    TotalCost = rs.sc.od.TotalCost,
                    Quantity = rs.sc.od.Quantity,
                    StatusCart = rs.sct.Name,
                    Id = rs.sc.od.Id,
                    OrderId = id,
                    ProductId = rs.sc.p.Id,
                    StatusCartId = rs.sct.Id
                });
            List<object> lOrderdetails = new List<object>();
            foreach (var item in orderdetails)
            {
                lOrderdetails.Add(item);
            }
            return lOrderdetails;
        }
        public int GetStatisticsOrders()
        {
            return _applicationContext.Orders.Count();
        }

        public List<object> GetAllOrdersDetailsSearch(string name, Guid id)
        {
            var orderdetails = _applicationContext.OrderDetails.Where(x => x.OrderId == id)
                .Join(_applicationContext.Products, od => od.ProductId, p => p.Id, (od, p) => new { od, p })
                .Join(_applicationContext.StatusCarts, sc => sc.od.StatusCartId, sct => sct.Id, (sc, sct) => new { sc, sct })
                .Where(s => s.sct.Name.Contains(name) || s.sc.p.Name.Contains(name))
                .Select(rs => new
                {
                    ProductName = rs.sc.p.Name,
                    TotalCost = rs.sc.od.TotalCost,
                    Quantity = rs.sc.od.Quantity,
                    StatusCart = rs.sct.Name,
                    Id = rs.sc.od.Id,
                    OrderId = id,
                    ProductId = rs.sc.p.Id,
                    StatusCartId = rs.sct.Id
                });
            List<object> lOrderdetails = new List<object>();
            foreach (var item in orderdetails)
            {
                lOrderdetails.Add(item);
            }
            return lOrderdetails;
        }
    }
}
