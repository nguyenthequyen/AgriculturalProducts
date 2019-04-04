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
using Serilog;

namespace AgriculturalProducts.Web.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Owner,Admin")]
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
            ILogger<HomeAdminController> logger,
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
            _logger = logger;
        }
        [HttpPost]
        [Route("product-statistics")]
        public async Task<IActionResult> ProductStatistics()
        {
            try
            {
                var productStatistics = _productService.ProductStatistics();
                return Ok(new Result() { Code = 200, Data = productStatistics, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê sản phẩm: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("provider-statistics")]
        public async Task<IActionResult> ProviderStatistics()
        {
            try
            {
                var providerStatistics = _providerService.ProviderStatistics();
                return Ok(new Result() { Code = 200, Data = providerStatistics, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê nhà cung cấp: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("product-type-statistics")]
        public async Task<IActionResult> ProductTypeStatistics()
        {
            try
            {
                var productTypeStatistics = _productTypeService.ProductTypeStatistics();
                return Ok(new Result() { Code = 200, Data = productTypeStatistics, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê loại sản phẩm: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("category-statistics")]
        public async Task<IActionResult> CategoryStatistics()
        {
            try
            {
                var categoryStatistics = _categoryService.CategoryStatistics();
                return Ok(new Result() { Code = 200, Data = categoryStatistics, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê danh mục sản phẩm: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("users-statistics")]
        public async Task<IActionResult> UsersStatistics()
        {
            try
            {
                var usersStatistics = _usersClientService.UsersStatistics();
                return Ok(new Result() { Code = 200, Data = usersStatistics, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê người dùng: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("order-cart-statistics")]
        public async Task<IActionResult> GetOrdersStatistics()
        {
            try
            {
                var usersStatistics = _usersClientService.UsersStatistics();
                return Ok(new Result() { Code = 200, Data = usersStatistics, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê đơn hàng: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("total-access")]
        public async Task<IActionResult> GetTotalAccess()
        {
            try
            {
                var totalAccess = _statisticsAdminService.TotalAccess();
                return Ok(new Result() { Code = 200, Data = totalAccess, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê lượt truy cập: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("total-revenue")]
        public async Task<IActionResult> GetTotalRevenue()
        {
            try
            {
                var totalRevenue = _applicationContext.OrderDetails.Sum(x => x.TotalCost);
                return Ok(new Result() { Code = 200, Data = totalRevenue, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê doanh thu: " + ex);
                return Ok(new Result() { Code = 200, Data = null, Error = ex.Message });
            }
        }
    }
}