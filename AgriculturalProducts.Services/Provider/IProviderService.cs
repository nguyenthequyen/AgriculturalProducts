using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IProviderService : IBaseService<Provider>
    {
        void InsertProvider(Provider provider);
    }
}
