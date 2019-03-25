using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
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
    //[Authorize(Roles = "Owner")]
    public class RolesAdminController : ControllerBase
    {
        private readonly IRolesService _rolseService;
        private readonly ILogger<RolesAdminController> _logger;
        private readonly ApplicationContext _applicationContext;
        public RolesAdminController(
            IRolesService rolseService,
            ApplicationContext applicationContext,
            ILogger<RolesAdminController> logger)
        {
            _rolseService = rolseService;
            _logger = logger;
            _applicationContext = applicationContext;
        }
        [HttpPost]
        [Route("insert-roles")]
        public async Task<IActionResult> CreatedRoles(Roles model)
        {
            try
            {
                _rolseService.InsertRoles(model);
                return Ok(new Result() { Data = "Thêm Roles thành công", Code = 200, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm roles: " + ex);
                return Ok(new Result() { Data = "Thêm Roles thất bại", Code = 200, Error = null });
            }
        }
        [HttpPost]
        [Route("get-all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var statusProducts = _rolseService.GetAllRoles();
                return Ok(new Result() { Code = 200, Data = statusProducts, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy dữ liệu tình trạng nhà cung cấp: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi lấy dữ liệu tình trạng nhà cung cấp" });
            }
        }
    }
}