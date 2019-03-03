using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class StatusProductRepository : BaseRepository<StatusProduct>, IStatusProductRepository
    {
        private readonly ApplicationContext _applicationContext;
        public StatusProductRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void DeleteStatusProduct(StatusProduct statusProduct)
        {
            Delete(statusProduct);
        }

        public IEnumerable<StatusProduct> GetAllStatusProduct()
        {
            return GetAllRecords();
        }

        public void InsertStatusProduct(StatusProduct statusProduct)
        {
            Add(statusProduct);
        }

        public void UpdateStatusProduct(StatusProduct statusProduct)
        {
            Update(statusProduct);
        }
    }
}
