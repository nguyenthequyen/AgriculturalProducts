using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IStatusProviderRepository : IBaseRepository<StatusProvider>
    {
        void InserttatusProvider(StatusProvider statusProvider);
        void UpdatetatusProvider(StatusProvider statusProvider);
        IEnumerable<StatusProvider> GetAlltatusProvider();
        void DeletetatusProvider(StatusProvider statusProvider);
    }
}
