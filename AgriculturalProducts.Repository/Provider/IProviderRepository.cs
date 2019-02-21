using System;
using System.Collections.Generic;
using System.Text;
using AgriculturalProducts.Models;

namespace AgriculturalProducts.Repository
{
    public interface IProviderRepository : IBaseRepository<Provider>
    {
        void InsertProduct(Provider provider);
    }
}
