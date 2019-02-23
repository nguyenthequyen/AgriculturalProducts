﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAdminController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        public ProductAdminController(
            IProductService productService,
            ILogger<ProductAdminController> logger)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpPost]
        [Route("insert-product")]
        public async Task<IActionResult> InsertProduct(Product product)
        {
            _productService.Add(product);
            return Ok();
        }
        [HttpPost]
        [Route("getproduct-paging")]
        public async Task<IActionResult> GetProductPagingnate(string sortOrder, string curentFilter, string searchString, int? page)
        {
            return Ok();
        }
        [HttpPost]
        [Route("update-product-type")]
        public async Task<IActionResult> UpdateProduct(Product provider)
        {
            _productService.UpdateProduct(provider);
            return Ok();
        }
        [HttpPost]
        [Route("get-product-type")]
        public async Task<IActionResult> GetAllProduct()
        {
            var provider = _productService.GetAllProduct();
            return Ok();
        }
        [HttpPost]
        [Route("delete-product-type")]
        public async Task<IActionResult> DeleteProduct(Product provider)
        {
            _productService.DeleteProduct(provider);
            return Ok();
        }
        [HttpPost]
        [Route("find-product-type")]
        public async Task<IActionResult> FindProductById(Guid id)
        {
            await _productService.FindProductById(id);
            return Ok();
        }
    }
}