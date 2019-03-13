using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class OrderAdminService : BaseService<Order>, IOrderAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderAdminRepository _reponsitory;
        public OrderAdminService(IUnitOfWork unitOfWork, IOrderAdminRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public int GetStatisticsOrder()
        {
            return _reponsitory.GetStatisticsOrders();
        }
    }
}
