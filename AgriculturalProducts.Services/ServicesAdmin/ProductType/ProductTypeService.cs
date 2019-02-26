using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class ProductTypeService : BaseService<ProductType>, IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductTypeService(IUnitOfWork unitOfWork, IProductTypeRepository productTypeRepository) : base(unitOfWork, productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public void DeleteProductType(List<ProductType> productType)
        {
            foreach (var item in productType)
            {
                Delete(item);
            }
            _unitOfWork.Commit();
        }

        public async Task<ProductType> FindProductTypeById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<ProductType> GetAllProductType()
        {
            return GetAllRecords();
        }

        public void InsertProductType(List<ProductType> productType)
        {
            foreach (var item in productType)
            {
                item.Id = Guid.NewGuid();
                item.ModifyDate = DateTime.Now;
                item.CreatedDate = DateTime.Now;
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public int ProductTypeStatistics()
        {
            return _productTypeRepository.ProductTypeStatistics();
        }

        public void UpdateProductType(List<ProductType> productType)
        {
            foreach (var item in productType)
            {
                Update(item);
            }
            _unitOfWork.Commit();
        }
    }
}
