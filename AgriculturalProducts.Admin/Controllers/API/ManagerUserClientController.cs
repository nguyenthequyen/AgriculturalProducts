using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class ManagerUserClientController : ControllerBase
    {
        private readonly IManagerUserService _managerUserService;
        private readonly ILogger<ManagerUserClientController> _logger;
        public ManagerUserClientController(
            IManagerUserService managerUserService,
            ILogger<ManagerUserClientController> logger
            )
        {
            _managerUserService = managerUserService;
            _logger = logger;
        }
        [HttpPost]
        [Route("get-userclient-infor")]
        public async Task<IActionResult> GetListUsers(PagingParams pagingParams)
        {
            try
            {
                var data = _managerUserService.GetListUsers(pagingParams);
                _logger.LogInformation("dữ liệu vào: " + pagingParams.SearchString);
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
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi lấy thông tin tài khoản" }); throw;
            }
        }
    }
}