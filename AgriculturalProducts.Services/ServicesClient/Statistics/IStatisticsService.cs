using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IStatisticsService : IBlogsService<Statistics>
    {
        void InsertStatistics(Statistics statistics);
    }
}
