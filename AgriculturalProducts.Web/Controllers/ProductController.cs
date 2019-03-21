using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult SearchProduct()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
    }
}