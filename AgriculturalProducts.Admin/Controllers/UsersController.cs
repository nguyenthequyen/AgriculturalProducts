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