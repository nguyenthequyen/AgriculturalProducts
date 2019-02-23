using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ProviderRepository(ApplicationContext applicationContext) : base( applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void DeleteProvider(Provider provider)
        {
            Delete(provider);
        }

        public async Task<Provider> FindProductById(Guid id)
        {
            return await FindProductById(id);
        }

        public IEnumerable<Provider> GetAllProvider()
        {
            return GetAllRecords();
        }

        public void InsertProduct(Provider provider)
        {
            Add(provider);
        }

        public int ProductStatistics()
        {
            return _applicationContext.Providers.Count();
        }

        public void UpdateProvider(Provider provider)
        {
            Update(provider);
        }
    }
}
