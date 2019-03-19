using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public List<object> GetListDiscountProducts()
        {
            return _reponsitory.GetListDiscountProducts();
        }

        public List<object> GetTopNewPoduct()
        {
            return _reponsitory.GetTopNewPoduct();
        }

        public List<object> GetProductDetails(Guid id)
        {
            return _reponsitory.GetProductDetails(id);
        }

        public List<object> FindProductByName(string name)
        {
            return _reponsitory.FindProductByName(name);
        }

        public void UpdateProduct(List<ProductOrder> productOrders)
        {
            foreach (var item in productOrders)
            {
                _reponsitory.UpdateProduct(item.Id, item.Quantity);
            }
            _unitOfWork.Commit();
        }
    }
}
