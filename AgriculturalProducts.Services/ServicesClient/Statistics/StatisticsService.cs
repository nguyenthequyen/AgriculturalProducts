using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class StatisticsService : BaseService<Statistics>, IStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatisticsRepostory _reponsitory;
        public StatisticsService(IUnitOfWork unitOfWork, IStatisticsRepostory reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void InsertStatistics(Statistics statistics)
        {
            Add(statistics);
            _unitOfWork.Commit();
        }
    }
}
