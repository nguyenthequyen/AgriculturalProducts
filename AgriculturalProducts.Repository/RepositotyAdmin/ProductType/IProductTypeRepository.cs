using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IProductTypeRepository:IBaseRepository<ProductType>
    {
        void InsertProductType(ProductType productType);
        void UpdateProductType(ProductType productType);
        IEnumerable<ProductType> GetAllProductType();
        void DeleteProductType(ProductType productType);
        Task<ProductType> FindProductById(Guid id);
        int ProductTypeStatistics();
    }
}
