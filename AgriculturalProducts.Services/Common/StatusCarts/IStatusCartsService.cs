using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IStatusCartsService: IBaseService<StatusCart>
    {
        void InsertStatusCart(StatusCart statusCart);
        StatusCart GetStatusCartsClient();
        List<StatusCart> GetStatusCart(Guid id);
    }
}
