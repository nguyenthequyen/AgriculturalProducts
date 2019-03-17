using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IRatesRepository : IBaseRepository<Rate>
    {
        void CreatedRate(Rate rate);
    }
}
