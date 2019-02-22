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

namespace AgriculturalProducts.APIWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        private readonly ApplicationContext _applicationContext;
        public ProductController(
            IProductService productService,
            ApplicationContext applicationContext,
            ILogger<ProviderController> logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
            _productService = productService;
        }
        [HttpPost]
        [Route("insert-product")]
        public async Task<IActionResult> InsertProduct(Product provider)
        {
            _productService.Add(provider);
            _logger.LogInformation("Test Log");
            return Ok();
        }
        [HttpPost]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProvider(Product provider)
        {
            _productService.Update(provider);
            return Ok();
        }
        [HttpPost]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProvider(Product provider)
        {
            _productService.Delete(provider);
            return Ok();
        }
        [HttpPost]
        [Route("get-product")]
        public async Task<IActionResult> GetAllProvider()
        {
            var provider = _productService.GetAllRecords();
            return Ok();
        }
        [HttpPost]
        [Route("find-product")]
        public async Task<IActionResult> FindProductById(Guid id)
        {
            await _productService.GetFirstOrDefault(id);
            return Ok();
        }
    }
}