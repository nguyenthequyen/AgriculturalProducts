using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Web.Controllers
{
    public class ManagerOrderController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }
    }
}