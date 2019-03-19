using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IStatusCartsRepository : IBaseRepository<StatusCart>
    {
        void InsertStatusCarts(StatusCart statusCart);
        StatusCart GetStatusCartsClient();
    }
}
