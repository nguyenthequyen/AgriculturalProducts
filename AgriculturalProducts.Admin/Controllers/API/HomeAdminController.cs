﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HomeAdminController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ApplicationContext _applicationContext;
        private readonly IProductTypeService _productTypeService;
        private readonly IProviderService _providerService;
        private readonly ICategoryService _categoryService;
        public HomeAdminController(
            IProductService productService,
            IProductTypeService productTypeService,
            IProviderService providerService,
            ICategoryService categoryService,
        ApplicationContext applicationContext)
        {
            _productService = productService;
            _productTypeService = productTypeService;
            _providerService = providerService;
            _categoryService = categoryService;
            _applicationContext = applicationContext;
        }
        [HttpPost]
        [Route("product-statistics")]
        public async Task<IActionResult> ProductStatistics()
        {
            var productStatistics = _productService.ProductStatistics();
            return Ok(new Result() { Code = 200, Data = productStatistics, Error = null });
        }
        [HttpPost]
        [Route("provider-statistics")]
        public async Task<IActionResult> ProviderStatistics()
        {
            var providerStatistics = _providerService.ProviderStatistics();
            return Ok(new Result() { Code = 200, Data = providerStatistics, Error = null });
        }
        [HttpPost]
        [Route("product-type-statistics")]
        public async Task<IActionResult> ProductTypeStatistics()
        {
            var productTypeStatistics = _productTypeService.ProductTypeStatistics();
            return Ok(new Result() { Code = 200, Data = productTypeStatistics, Error = null });
        }
        [HttpPost]
        [Route("category-statistics")]
        public async Task<IActionResult> CategoryStatistics()
        {
            var categoryStatistics = _categoryService.CategoryStatistics();
            return Ok(new Result() { Code = 200, Data = categoryStatistics, Error = null });
        }
    }
}