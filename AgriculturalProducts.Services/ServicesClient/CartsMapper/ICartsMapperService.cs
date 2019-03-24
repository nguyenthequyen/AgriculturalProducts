using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface ICartsMapperService:IBaseService<ProductCart>
    {
        ProductCart GetProductCart(Guid id);
    }
}
