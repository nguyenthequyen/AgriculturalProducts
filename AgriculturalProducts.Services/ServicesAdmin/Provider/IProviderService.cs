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
        void InsertProvider(List<Provider> provider);
        void UpdateProvider(List<Provider> provider);
        IEnumerable<Provider> GetAllProvider();
        void DeleteProvider(List<Provider> provider);
        Task<Provider> FindProviderById(Guid id);
        int ProviderStatistics();
        PageList<Provider> GetProviderPageList(PagingParams pagingParams);
    }
}
