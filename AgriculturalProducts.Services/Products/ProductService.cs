using AgriculturalProducts.Models;
using AgriculturalProducts.Services;

namespace AgriculturalProducts.Repository
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

        public void InsertProduct(Product product)
        {
            _productRepository.Add(product);
        }
    }
}
