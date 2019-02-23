using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IProductTypeService : IBaseService<ProductType>
    {
        void InsertProductType(ProductType productType);
        void UpdateProductType(ProductType productType);
        IEnumerable<ProductType> GetAllProductType();
        void DeleteProductType(ProductType productType);
        Task<ProductType> FindProductTypeById(Guid id);
    }
}
