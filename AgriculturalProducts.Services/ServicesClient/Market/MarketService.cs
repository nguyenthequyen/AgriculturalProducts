using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class MarketService : BaseService<Product>, IMarketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMarketRepository _reponsitory;
        private readonly IProductRepository _productRepository;
        public MarketService(IUnitOfWork unitOfWork, IProductRepository productRepository, IMarketRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
            _productRepository = productRepository;
        }

        public PageList<Product> GetMarketPageList(PagingParams pagingParams)
        {
            var providersdb = _productRepository.GetAllRecords();
            List<Product> providers = providersdb.ToList();
            var query = providers.AsQueryable();
            return new PageList<Product>(query, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
