using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IStatusProviderService : IBlogsService<StatusProvider>
    {
        void InsertStatusProvider(List<StatusProvider> statusProvider);
        void UpdateStatusProvider(List<StatusProvider> statusProvider);
        IEnumerable<StatusProvider> GetAllStatusProvider();
        void DeleteStatusProvider(List<StatusProvider> statusProvider);
    }
}
