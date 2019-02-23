using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeAdminController : ControllerBase
    {
        private readonly IProductService _productService;
        public HomeAdminController(IProductService productService)
        {
            _productService = productService;
        }
        [Route("product-statistics")]
        public async Task<IActionResult> ProductStatistics()
        {
            var productStatistics = _productService.ProductStatistics();
            return Ok(new Result() { Code = 200, Data = productStatistics, Error = null });
        }
        [HttpPost]
        [Route("insert-product")]
        public async Task<IActionResult> InsertProduct(Product product)
        {
            _productService.InsertProduct(product);
            return Ok();
        }
    }
}