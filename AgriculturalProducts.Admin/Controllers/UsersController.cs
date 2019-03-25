using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Admin.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Client()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
    }
}