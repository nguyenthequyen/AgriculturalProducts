using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class StatisticsRepostory : BaseRepository<Statistics>, IStatisticsRepostory
    {
        private readonly ApplicationContext _applicationContext;
        public StatisticsRepostory(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void InsertStatistics(Statistics statistics)
        {
            Add(statistics);
        }
    }
}
