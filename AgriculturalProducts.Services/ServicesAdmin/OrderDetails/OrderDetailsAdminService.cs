using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class OrderDetailsAdminService : BaseService<OrderDetails>, IOrderDetailsAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailsAdminRepository _reponsitory;
        public OrderDetailsAdminService(IUnitOfWork unitOfWork, IOrderDetailsAdminRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public async Task<OrderDetails> GetOrderDetailsById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }
    }
}
