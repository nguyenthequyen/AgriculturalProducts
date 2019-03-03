using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{

    public class StatusProviderService : BaseService<StatusProvider>, IStatusProviderService
    {
        private readonly IStatusProviderRepository _statusProviderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StatusProviderService(IUnitOfWork unitOfWork, IStatusProviderRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _statusProviderRepository = reponsitory;
            _unitOfWork = unitOfWork;
        }

        public void DeleteStatusProvider(List<StatusProvider> statusProvider)
        {
            foreach (var item in statusProvider)
            {
                Delete(item);
            }
            _unitOfWork.Commit();
        }

        public IEnumerable<StatusProvider> GetAllStatusProvider()
        {
            return GetAllRecords();
        }

        public void InsertStatusProvider(List<StatusProvider> statusProvider)
        {
            foreach (var item in statusProvider)
            {
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public void UpdateStatusProvider(List<StatusProvider> statusProvider)
        {
            foreach (var item in statusProvider)
            {
                Update(item);
            }
            _unitOfWork.Commit();
        }
    }
}
