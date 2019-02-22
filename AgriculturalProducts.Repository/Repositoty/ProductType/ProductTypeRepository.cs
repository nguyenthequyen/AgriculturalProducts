using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ProductTypeRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void DeleteProductType(ProductType productType)
        {
            Delete(productType);
        }

        public async Task<ProductType> FindProductById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<ProductType> GetAllProductType()
        {
            return GetAllRecords();
        }

        public void InsertProductType(ProductType productType)
        {
            Add(productType);
        }

        public void UpdateProductType(ProductType productType)
        {
            Update(productType);
        }
    }
}
