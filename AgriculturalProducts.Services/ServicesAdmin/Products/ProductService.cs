using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteProduct(List<Product> product)
        {
            foreach (var item in product)
            {
                Delete(item);
            }
            _unitOfWork.Commit();
        }

        public async Task<Product> FindProductById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return GetAllRecords();
        }

        public PageList<Product> GetProductPageList(PagingParams pagingParams)
        {
            if (string.IsNullOrEmpty(pagingParams.SearchString))
            {
                var providersdb = _productRepository.GetAllProduct().OrderByDescending(x => x.ModifyDate);
                List<Product> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<Product>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
            else
            {
                var providersdb = _productRepository.GetAllProduct().Where(x => x.Name.Contains(pagingParams.SearchString)).OrderByDescending(x => x.ModifyDate);
                List<Product> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<Product>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
        }

        public void InsertProduct(List<Product> product)
        {
            foreach (var item in product)
            {
                item.Id = Guid.NewGuid();
                item.ModifyDate = DateTime.Now;
                item.CreatedDate = DateTime.Now;
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public int ProductStatistics()
        {
            return _productRepository.ProductStatistics();
        }

        public void UpdateProduct(List<Product> product)
        {
            foreach (var item in product)
            {
                item.ModifyDate = DateTime.Now;
                Update(item);
            }
            _unitOfWork.Commit();
        }
    }
}
