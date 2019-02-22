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

        public void DeleteProductType(ProductType productType)
        {
            Delete(productType);
        }

        public async Task<ProductType> FindProductTypeById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<ProductType> GetAllProvider()
        {
            return GetAllRecords();
        }

        public void InsertProductType(ProductType productType)
        {
            productType.Id = Guid.NewGuid();
            productType.ModifyDate = DateTime.Now;
            productType.CreatedDate = DateTime.Now;
            Add(productType);
        }

        public void UpdateProductType(ProductType productType)
        {
            Update(productType);
        }
    }
}
