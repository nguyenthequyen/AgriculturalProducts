using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IProviderService : IBaseService<Provider>
    {
        void InsertProvider(Provider provider);
        void UpdateProvider(Provider provider);
        IEnumerable<Provider> GetAllProvider();
        void DeleteProvider(Provider provider);
        Task<Provider> FindProviderById(Guid id);
        int ProviderStatistics();
    }
}
