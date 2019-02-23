using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;

namespace AgriculturalProducts.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _productRepository = reponsitory;
            _unitOfWork = unitOfWork;
        }

        public void DeleteProduct(Product productType)
        {
            Delete(productType);
        }

        public async Task<Product> FindProductById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return GetAllRecords();
        }

        public void InsertProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            product.ModifyDate = DateTime.Now;
            product.CreatedDate = DateTime.Now;
            Add(product);
        }

        public int ProductStatistics()
        {
            return _productRepository.ProductStatistics();
        }

        public void UpdateProduct(Product product)
        {
            product.ModifyDate = DateTime.Now;
            Update(product);
        }
    }
}
