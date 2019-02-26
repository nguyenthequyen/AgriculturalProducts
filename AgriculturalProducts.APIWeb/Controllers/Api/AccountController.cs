using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        private readonly ApplicationContext _applicationContext;
        public AccountController(
            IProductService productService,
            ApplicationContext applicationContext,
            ILogger<AccountController> logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
            _productService = productService;
        }
        [HttpPost]
        [Route("insert-product")]
        public async Task<IActionResult> InsertProduct(List<Product> product)
        {
            _productService.InsertProduct(product);
            return Ok();
        }
    }
}