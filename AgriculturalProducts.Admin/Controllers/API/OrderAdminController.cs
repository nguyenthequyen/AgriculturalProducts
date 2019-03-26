using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
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
    //[Authorize(Roles = "Owner,Admin")]
    public class OrderAdminController : ControllerBase
    {
        private readonly IOrderAdminService _orderAdminService;
        private readonly ILogger<OrderAdminController> _logger;
        public OrderAdminController(
            IOrderAdminService orderAdminService,
            ILogger<OrderAdminController> logger
            )
        {
            _orderAdminService = orderAdminService;
            _logger = logger;
        }
        [HttpPost]
        [Route("get-order-paging")]
        public async Task<IActionResult> GetOrderPagingnate([FromBody] PagingParams pagingParams)
        {
            try
            {
                var data = _orderAdminService.GetOrderPagingnate(pagingParams);
                Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
                var output = new OutPutModel<object>
                {
                    Paging = data.GetHeader(),
                    Items = data.List.ToList(),
                };
                return Ok(new Result() { Code = 200, Data = output, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu đơn hàng: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Lỗi lấy dữ liệu phân trang" });
            }
        }
    }
}