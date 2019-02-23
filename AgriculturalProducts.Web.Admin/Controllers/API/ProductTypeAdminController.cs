using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeAdminController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly ILogger _logger;
        public ProductTypeAdminController(
            IProductTypeService productTypeService,
            ILogger<ProductTypeAdminController> logger
        )
        {
            _productTypeService = productTypeService;
            _logger = logger;
        }
        [HttpPost]
        [Route("inssert-product-type")]
        public async Task<IActionResult> InsertProductType(ProductType productType)
        {
            _productTypeService.InsertProductType(productType);
            return Ok();
        }
        [HttpPost]
        [Route("update-product-type")]
        public async Task<IActionResult> UpdateProductType(ProductType provider)
        {
            _productTypeService.UpdateProductType(provider);
            return Ok();
        }
        [HttpPost]
        [Route("get-product-type")]
        public async Task<IActionResult> GetAllProductType()
        {
            var provider = _productTypeService.GetAllProductType();
            return Ok();
        }
        [HttpPost]
        [Route("delete-product-type")]
        public async Task<IActionResult> DeleteProductType(ProductType provider)
        {
            _productTypeService.DeleteProductType(provider);
            return Ok();
        }
        [HttpPost]
        [Route("find-product-type")]
        public async Task<IActionResult> FindProductTypeById(Guid id)
        {
            await _productTypeService.FindProductTypeById(id);
            return Ok();
        }
    }
}