using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class ProviderService : BaseService<Provider>, IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProviderService(IUnitOfWork unitOfWork, IProviderRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _providerRepository = reponsitory;
            _unitOfWork = unitOfWork;
        }

        public void DeleteProvider(Provider provider)
        {
            Delete(provider);
        }

        public async Task<Provider> FindProviderById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Provider> GetAllProvider()
        {
            return GetAllRecords();
        }

        public void InsertProvider(Provider provider)
        {
            provider.Id = Guid.NewGuid();
            provider.ModifyDate = DateTime.Now;
            provider.CreatedDate = DateTime.Now;
            Add(provider);
        }

        public int ProviderStatistics()
        {
            return _providerRepository.ProductStatistics();
        }

        public void UpdateProvider(Provider provider)
        {
            provider.ModifyDate = DateTime.Now;
            Update(provider);
        }
    }
}
