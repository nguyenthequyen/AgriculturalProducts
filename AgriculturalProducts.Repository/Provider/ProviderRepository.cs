using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ProviderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void InsertProduct(Provider provider)
        {
            _applicationContext.Add(provider);
        }
    }
}
