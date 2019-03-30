using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IStatusCartsRepository : IBaseRepository<StatusCart>
    {
        void InsertStatusCarts(StatusCart statusCart);
        StatusCart GetStatusCartsClient();
        List<StatusCart> GetStatusCart(Guid id);
    }
}
