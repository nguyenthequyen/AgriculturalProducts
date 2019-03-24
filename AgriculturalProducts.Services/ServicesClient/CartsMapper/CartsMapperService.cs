using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class CartsMapperService : BaseService<ProductCart>, ICartsMapperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartsMapperRepository _reponsitory;
        public CartsMapperService(IUnitOfWork unitOfWork, ICartsMapperRepository reponsitory) : base(unitOfWork, reponsitory)
        {
        }

        public ProductCart GetProductCart(Guid id)
        {
            return _reponsitory.GetProductCart(id);
        }
    }
}
