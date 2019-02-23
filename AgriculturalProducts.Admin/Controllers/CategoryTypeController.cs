using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Admin.Controllers
{
    public class CategoryTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}