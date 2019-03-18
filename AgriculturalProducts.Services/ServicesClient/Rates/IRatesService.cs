using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IRatesService : IBaseService<Rate>
    {
        void CreatedRate(Rate rate);
        List<object> GetAllRates(Guid id);
    }
}
