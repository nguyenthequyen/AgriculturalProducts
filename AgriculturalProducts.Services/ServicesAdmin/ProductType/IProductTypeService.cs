using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IProductTypeService : IBaseService<ProductType>
    {
        void InsertProductType(List<ProductType> productType);
        void UpdateProductType(List<ProductType> productType);
        IEnumerable<ProductType> GetAllProductType();
        void DeleteProductType(List<ProductType> productType);
        Task<ProductType> FindProductTypeById(Guid id);
        int ProductTypeStatistics();
    }
}
