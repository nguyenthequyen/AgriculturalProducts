﻿using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IStatisticsAdminService:IBaseService<Statistics>
    {
        List<object> StatisticsAccessSystem();
    }
}