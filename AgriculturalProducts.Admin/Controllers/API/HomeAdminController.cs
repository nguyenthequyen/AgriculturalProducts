using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
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
        private readonly ApplicationContext _applicationContext;
        public HomeAdminController(IProductService productService
            ,ApplicationContext applicationContext)
        {
            _productService = productService;
            _applicationContext = applicationContext;
        }
        [HttpPost]
        [Route("product-statistics")]
        public async Task<IActionResult> ProductStatistics()
        {
            var productStatistics = _applicationContext.Products.Count();
            return Ok(new Result() { Code = 200, Data = productStatistics, Error = null });
        }
        [HttpPost]
        [Route("provider-statistics")]
        public async Task<IActionResult> ProviderStatistics()
        {
            var providerStatistics = _applicationContext.Providers.Count();
            return Ok(new Result() { Code = 200, Data = providerStatistics, Error = null });
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