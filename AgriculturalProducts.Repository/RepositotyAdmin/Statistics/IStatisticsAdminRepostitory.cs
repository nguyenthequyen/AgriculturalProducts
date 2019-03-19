using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IStatisticsAdminRepostitory : IBaseRepository<Statistics>
    {
        List<object> StatisticsAccessSystem();
        List<object> StatisticsUser();
        List<object> StatisticsOrder();
        int StatisticsOrderTotal();
    }
}
