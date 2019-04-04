using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketApiController : ControllerBase
    {
        private readonly IMarketService _marketService;
        private readonly ILogger<MarketApiController> _logger;

        public MarketApiController(
            IMarketService marketService,
            ILogger<MarketApiController> logger
            )
        {
            _marketService = marketService;
            _logger = logger;
        }
        [HttpPost]
        [Route("get-market-product")]
        public async Task<IActionResult> GetMarketProduct(PagingParams pagingParams)
        {
            try
            {
                var data = _marketService.GetMarketPageList(pagingParams);
                Response.Headers.Add("X-Pagination", data.GetHeader().ToJson());
                var output = new OutPutModel<Product>
                {
                    Paging = data.GetHeader(),
                    Items = data.List.ToList(),
                };
                return Ok(new Result() { Code = 200, Data = output, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu phân trang: " + ex);
                return Ok(new Result() { Code = ex.HResult, Data = null, Error = "Lỗi lấy dữ liệu phân trang" });
            }
        }
    }
}