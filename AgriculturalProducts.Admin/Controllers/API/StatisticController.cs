using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticsAdminService _statisticsAdminService;
        public StatisticController(IStatisticsAdminService statisticsAdminService)
        {
            _statisticsAdminService = statisticsAdminService;
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
                return Ok(new Result() { Data = null, Code = (int)HttpStatusCode.InternalServerError, Error = ex.Message });
            }
        }
    }
}