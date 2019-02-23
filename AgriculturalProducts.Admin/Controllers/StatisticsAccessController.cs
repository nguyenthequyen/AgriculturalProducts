using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Admin.Controllers.API
{
    public class StatisticsAccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}