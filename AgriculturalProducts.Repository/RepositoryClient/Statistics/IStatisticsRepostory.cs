﻿using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IStatisticsRepostory : IBaseRepository<Statistics>
    {
        void InsertStatistics(Statistics statistics);
    }
}
