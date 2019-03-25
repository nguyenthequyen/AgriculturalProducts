using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ServerInternal()
        {
            return View();
        }
        public IActionResult PageNotFound()
        {
            return View();
        }
        public IActionResult AccessDenine()
        {
            return View();
        }

        public IActionResult Provider()
        {
            return View();
        }
        public IActionResult CategoryType()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Carts()
        {
            return View();
        }
    }
}
