using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Action = AgriculturalProducts.Models.Action;

namespace AgriculturalProducts.Repository
{
    public class StatisticsAdminRepostitory : BaseRepository<Statistics>, IStatisticsAdminRepostitory
    {
        private readonly ApplicationContext _applicationContext;
        public StatisticsAdminRepostitory(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<object> StatisticsAccessSystem()
        {
            var statistics = _applicationContext.Statistics.Where(x => x.Action == (int)Action.Visitor).GroupBy(x => x.CreatedDate.Day).Select(x=>new {
                Count = x.Key,
                Date = x.Distinct().Count()
            }).ToList();
            List<object> listStatistics = new List<object>();
            foreach (var item in statistics)
            {
                listStatistics.Add(item);
            }
            return listStatistics;
        }
    }
}
