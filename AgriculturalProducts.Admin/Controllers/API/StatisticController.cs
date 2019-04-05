using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Owner,Admin")]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticsAdminService _statisticsAdminService;
        private readonly ILogger<StatisticController> _logger;
        public StatisticController(
            IStatisticsAdminService statisticsAdminService,
            ILogger<StatisticController> logger
            )
        {
            _statisticsAdminService = statisticsAdminService;
            _logger = logger;
        }
        [HttpPost]
        [Route("statistics-access")]
        public async Task<IActionResult> GetAccessStatistics()
        {
            try
            {
                var data = _statisticsAdminService.StatisticsAccessSystem();
                return Ok(new Result() { Data = data, Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê biều đồ lượt truy cập: " + ex);
                return Ok(new Result() { Data = null, Code = (int)HttpStatusCode.InternalServerError, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("statistics-user")]
        public async Task<IActionResult> StatisticsUser()
        {
            try
            {
                var data = _statisticsAdminService.StatisticsUser();
                return Ok(new Result() { Data = data, Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê biều đồ tài khoản: " + ex);
                return Ok(new Result() { Data = null, Code = (int)HttpStatusCode.InternalServerError, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("statistics-order")]
        public async Task<IActionResult> StatisticsOrder()
        {
            try
            {
                var data = _statisticsAdminService.StatisticsOrder();
                return Ok(new Result() { Data = data, Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê biều đồ đơn hàng: " + ex);
                return Ok(new Result() { Data = null, Code = (int)HttpStatusCode.InternalServerError, Error = ex.Message });
            }
        }
        [HttpPost]
        [Route("statistics-order-total")]
        public async Task<IActionResult> StatisticsOrderTotal()
        {
            try
            {
                var data = _statisticsAdminService.StatisticsOrderTotal();
                return Ok(new Result() { Data = data, Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu thống kê tổng đơn hàng: " + ex);
                return Ok(new Result() { Data = null, Code = (int)HttpStatusCode.InternalServerError, Error = ex.Message });
            }
        }
    }
}