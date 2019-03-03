using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class StatusProductService : BaseService<StatusProduct>, IStatusProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatusProductRepository _reponsitory;
        public StatusProductService(IUnitOfWork unitOfWork, IStatusProductRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void DeleteStatusProduct(List<StatusProduct> statusProduct)
        {
            foreach (var item in statusProduct)
            {
                Delete(item);
            }
            _unitOfWork.Commit();
        }

        public IEnumerable<StatusProduct> GetAllStatusProduct()
        {
            return GetAllRecords();
        }

        public void InsertStatusProduct(List<StatusProduct> statusProduct)
        {
            foreach (var item in statusProduct)
            {
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public void UpdateStatusProduct(List<StatusProduct> statusProduct)
        {
            foreach (var item in statusProduct)
            {
                Update(item);
            }
            _unitOfWork.Commit();
        }
    }
}
