using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IStatusProductRepository : IBaseRepository<StatusProduct>
    {
        void InsertStatusProduct(StatusProduct roles);
        void UpdateStatusProduct(StatusProduct roles);
        IEnumerable<StatusProduct> GetAllStatusProduct();
        void DeleteStatusProduct(StatusProduct roles);
    }
}
