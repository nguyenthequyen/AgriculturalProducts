using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class ProductClientService : BaseService<Product>, IProductClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductClientRepository _reponsitory;
        public ProductClientService(IUnitOfWork unitOfWork, IProductClientRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public List<object> GetTopNewPoduct()
        {
            return _reponsitory.GetTopNewPoduct();
        }
    }
}
