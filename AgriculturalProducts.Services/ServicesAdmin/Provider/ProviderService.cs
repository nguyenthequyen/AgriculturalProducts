using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteProvider(List<Provider> provider)
        {
            foreach (var item in provider)
            {
                _providerRepository.Delete(item);
            }
            _unitOfWork.Commit();
        }

        public async Task<Provider> FindProviderById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Provider> GetAllProvider()
        {
            return GetAllRecords();
        }

        public PageList<Provider> GetProviderPageList(PagingParams pagingParams)
        {
            if (string.IsNullOrEmpty(pagingParams.SearchString))
            {
                var providersdb = _providerRepository.GetAllRecords().OrderByDescending(x => x.ModifyDate);
                List<Provider> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<Provider>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
            else
            {
                var providersdb = _providerRepository.GetAllRecords().Where(x => x.Name.Contains(pagingParams.SearchString)).OrderByDescending(x => x.ModifyDate);
                List<Provider> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<Provider>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
        }

        public void InsertProvider(List<Provider> provider)
        {
            foreach (var item in provider)
            {
                item.Id = Guid.NewGuid();
                item.ModifyDate = DateTime.Now;
                item.CreatedDate = DateTime.Now;
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public int ProviderStatistics()
        {
            return _providerRepository.ProductStatistics();
        }

        public void UpdateProvider(List<Provider> provider)
        {
            foreach (var item in provider)
            {
                item.ModifyDate = DateTime.Now;
                Update(item);
            }
        }
    }
}
