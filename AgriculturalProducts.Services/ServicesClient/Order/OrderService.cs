using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRpository _reponsitory;
        public OrderService(IUnitOfWork unitOfWork, IOrderRpository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void AddOrder(Order order)
        {
            order.CreatedDate = DateTime.Now;
            order.ModifyDate = DateTime.Now;
            Add(order);
            _unitOfWork.Commit();
        }

        public List<object> GetListOrder(Guid userId)
        {
            return _reponsitory.GetListOrder(userId);
        }
    }
}
