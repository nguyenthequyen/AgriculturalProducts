using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IStatusProductService:IBlogsService<StatusProduct>
    {
        void InsertStatusProduct(List<StatusProduct> statusProduct);
        void UpdateStatusProduct(List<StatusProduct> statusProduct);
        IEnumerable<StatusProduct> GetAllStatusProduct();
        void DeleteStatusProduct(List<StatusProduct> statusProduct);
    }
}
