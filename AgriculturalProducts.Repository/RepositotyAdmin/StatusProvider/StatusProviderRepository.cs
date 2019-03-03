using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class StatusProviderRepository : BaseRepository<StatusProvider>, IStatusProviderRepository
    {
        private readonly ApplicationContext _applicationContext;
        public StatusProviderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void DeletetatusProvider(StatusProvider statusProvider)
        {
            Delete(statusProvider);
        }

        public IEnumerable<StatusProvider> GetAlltatusProvider()
        {
            return GetAllRecords();
        }

        public void InserttatusProvider(StatusProvider statusProvider)
        {
            Add(statusProvider);
        }

        public void UpdatetatusProvider(StatusProvider statusProvider)
        {
            Update(statusProvider);
        }
    }
}
