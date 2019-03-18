using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class RatesService : BaseService<Rate>, IRatesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRatesRepository _ratesRepository;
        public RatesService(IUnitOfWork unitOfWork, IRatesRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _ratesRepository = reponsitory;
        }

        public void CreatedRate(Rate rate)
        {
            Add(rate);
            _unitOfWork.Commit();
        }

        public List<object> GetAllRates(Guid id)
        {
            return _ratesRepository.GetAllRates(id);
        }
    }
}
