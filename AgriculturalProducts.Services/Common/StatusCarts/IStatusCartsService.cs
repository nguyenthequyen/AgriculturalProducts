using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IStatusCartsService: IBaseService<StatusCart>
    {
        void InsertStatusCart(StatusCart statusCart);
        StatusCart GetStatusCartsClient();
    }
}
