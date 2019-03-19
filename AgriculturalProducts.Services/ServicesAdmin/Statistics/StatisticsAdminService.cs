using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class StatisticsAdminService : BaseService<Statistics>, IStatisticsAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatisticsAdminRepostitory _reponsitory;
        public StatisticsAdminService(IUnitOfWork unitOfWork, IStatisticsAdminRepostitory reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public List<object> StatisticsAccessSystem()
        {
            return _reponsitory.StatisticsAccessSystem();
        }

        public List<object> StatisticsOrder()
        {
            return _reponsitory.StatisticsOrder();
        }

        public int StatisticsOrderTotal()
        {
            return _reponsitory.StatisticsOrderTotal();
        }

        public List<object> StatisticsUser()
        {
            return _reponsitory.StatisticsUser();
        }
    }
}
