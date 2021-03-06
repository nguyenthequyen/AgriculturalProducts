﻿using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class OrderDetailsService : BaseService<OrderDetails>, IOrderDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailsAdminRepository _reponsitory;
        public OrderDetailsService(IUnitOfWork unitOfWork, IOrderDetailsAdminRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            orderDetails.CreatedDate = DateTime.Now;
            orderDetails.ModifyDate = DateTime.Now;
            Add(orderDetails);
        }
    }
}
