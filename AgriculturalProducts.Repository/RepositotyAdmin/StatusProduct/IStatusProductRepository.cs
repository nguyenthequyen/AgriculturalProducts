using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IStatusProductRepository : IBaseRepository<StatusProduct>
    {
        void InsertStatusProduct(StatusProduct statusProduct);
        void UpdateStatusProduct(StatusProduct statusProduct);
        IEnumerable<StatusProduct> GetAllStatusProduct();
        void DeleteStatusProduct(StatusProduct roles);
    }
}
