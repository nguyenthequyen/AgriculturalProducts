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
            var statistics = _applicationContext.Statistics.Where(x => x.Action == (int)Action.Visitor).GroupBy(x => x.CreatedDate.Day).Select(x => new
            {
                label = x.Key,
                y = x.Distinct().Count()
            }).OrderBy(x => x.label).ToList();
            List<object> listStatistics = new List<object>();
            foreach (var item in statistics)
            {
                listStatistics.Add(item);
            }
            return listStatistics;
        }

        public List<object> StatisticsOrder()
        {
            var statistics = _applicationContext.Statistics.Where(x => x.Action == (int)Action.Order).GroupBy(x => x.CreatedDate.Day).Select(x => new
            {
                label = x.Key,
                y = x.Distinct().Count()
            }).OrderBy(x => x.label).ToList();
            List<object> listStatistics = new List<object>();
            foreach (var item in statistics)
            {
                listStatistics.Add(item);
            }
            return listStatistics;
        }

        public int StatisticsOrderTotal()
        {
            return _applicationContext.Orders.Count();
        }

        public List<object> StatisticsUser()
        {
            var statistics = _applicationContext.Statistics.Where(x => x.Action == (int)Action.CreatedUser).GroupBy(x => x.CreatedDate.Day).Select(x => new
            {
                label = x.Key,
                y = x.Distinct().Count()
            }).OrderBy(x => x.label).ToList();
            List<object> listStatistics = new List<object>();
            foreach (var item in statistics)
            {
                listStatistics.Add(item);
            }
            return listStatistics;
        }
    }
}
