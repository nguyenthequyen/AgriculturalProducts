using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Admin.Controllers
{
    public class UnitsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}