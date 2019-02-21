using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class ProviderService : BaseService<Provider>, IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProviderService(IUnitOfWork unitOfWork, IProviderRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _providerRepository = reponsitory;
        }

        public void InsertProvider(Provider provider)
        {
            _providerRepository.Add(provider);
        }
    }
}
