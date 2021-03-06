﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.APIWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRatesService _ratesService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<RatesController> _logger;
        public RatesController(
            IRatesService ratesService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<RatesController> logger)
        {
            _ratesService = ratesService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        [Route("created-rates")]
        [Authorize(Roles = "Users")]
        public async Task<IActionResult> CreatedRate(Rate rate)
        {
            try
            {
                var claimsIdentity = _httpContextAccessor.HttpContext.User.Claims;
                var data = new UsersInfor();
                var userId = claimsIdentity.FirstOrDefault(x => x.Type == "UserId").Value;
                rate.UserId = Guid.Parse(userId);
                _ratesService.CreatedRate(rate);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "Thêm bình luận thành công", Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Tạo comment thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Thêm bình luận thất bại" });
            }
        }
        [HttpPost]
        [Route("get-all-rates")]
        public async Task<IActionResult> GetAllRates([FromBody] ProductId id)
        {
            try
            {
                var data = _ratesService.GetAllRates(id.Id);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lấy dữ liệu đánh giá thất bại: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Lấy dữ liệu đánh giá thất bại" });
            }
        }
    }
}