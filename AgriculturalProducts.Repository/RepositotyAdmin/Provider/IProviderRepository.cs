using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgriculturalProducts.Models;

namespace AgriculturalProducts.Repository
{
    public interface IProviderRepository : IBaseRepository<Provider>
    {
        void InsertProduct(Provider provider);
        void UpdateProvider(Provider provider);
        IEnumerable<Provider> GetAllProvider();
        void DeleteProvider(Provider provider);
        Task<Provider> FindProductById(Guid id);
        int ProductStatistics();
    }
}
