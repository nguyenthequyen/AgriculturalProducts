using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class CategoriesClientService : BaseService<Category>, ICategoriesClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoriesClientRepository _reponsitory;
        public CategoriesClientService(IUnitOfWork unitOfWork, ICategoriesClientRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public IEnumerable<Category> GetCategories()
        {
            return GetAllRecords();
        }

        public List<object> GetProductByCategory(Guid name)
        {
            return _reponsitory.GetProductByCategory(name);
        }
    }
}
