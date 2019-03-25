using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Owner,Admin")]
    public class HomeAdminController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ApplicationContext _applicationContext;
        private readonly IProductTypeService _productTypeService;
        private readonly IProviderService _providerService;
        private readonly ICategoryService _categoryService;
        private readonly IUserClientService _usersClientService;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IStatisticsAdminService _statisticsAdminService;
        private readonly ILogger<HomeAdminController> _logger;
        public HomeAdminController(
            IProductService productService,
            IProductTypeService productTypeService,
            IProviderService providerService,
            ICategoryService categoryService,
            IUserClientService userClientService,
            IEmailSenderService emailSenderService,
            IStatisticsAdminService statisticsAdminService,
        ApplicationContext applicationContext)
        {
            _productService = productService;
            _productTypeService = productTypeService;
            _providerService = providerService;
            _categoryService = categoryService;
            _applicationContext = applicationContext;
            _usersClientService = userClientService;
            _emailSenderService = emailSenderService;
            _statisticsAdminService = statisticsAdminService;
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
        [HttpPost]
        [Route("users-statistics")]
        public async Task<IActionResult> UsersStatistics()
        {
            var usersStatistics = _usersClientService.UsersStatistics();
            return Ok(new Result() { Code = 200, Data = usersStatistics, Error = null });
        }
        [HttpPost]
        [Route("order-cart-statistics")]
        public async Task<IActionResult> GetOrdersStatistics()
        {
            //_emailSenderService.SendEmail("", "", "");
            var usersStatistics = _usersClientService.UsersStatistics();
            return Ok(new Result() { Code = 200, Data = usersStatistics, Error = null });
        }
        [HttpPost]
        [Route("total-access")]
        public async Task<IActionResult> GetTotalAccess()
        {
            var totalAccess = _statisticsAdminService.TotalAccess();
            return Ok(new Result() { Code = 200, Data = totalAccess, Error = null });
        }
    }
}