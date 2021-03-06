﻿using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<object> GetAllOrders()
        {
            return _reponsitory.GetAllOrders();
        }

        public PageList<object> GetOrderPagingnate(PagingParams pagingParams)
        {
            if (string.IsNullOrEmpty(pagingParams.SearchString))
            {
                var providersdb = _reponsitory.GetAllOrders();
                List<object> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<object>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
            else
            {
                var providersdb = _reponsitory.GetAllOrdersSearch(pagingParams.SearchString);
                List<object> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<object>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
        }
        public PageList<object> GetOrderDetailsPagingnate(PagingParamsOrderId pagingParams)
        {
            if (string.IsNullOrEmpty(pagingParams.SearchString))
            {
                var providersdb = _reponsitory.GetAllOrdersDetails(pagingParams.Id);
                List<object> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<object>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
            else
            {
                var providersdb = _reponsitory.GetAllOrdersDetailsSearch(pagingParams.SearchString, pagingParams.Id);
                List<object> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<object>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
        }
        public int GetStatisticsOrder()
        {
            return _reponsitory.GetStatisticsOrders();
        }
    }
}
