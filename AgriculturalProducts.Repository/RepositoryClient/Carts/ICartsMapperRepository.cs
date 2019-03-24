using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface ICartsMapperRepository : IBaseRepository<ProductCart>
    {
        ProductCart GetProductCart(Guid id);
    }
}
