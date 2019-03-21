using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Admin.Models;
using AgriculturalProducts.Web.JwtHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {
        private readonly IUserAdminService _userAdminService;
        private readonly ILogger<UserAdminController> _logger;
        private readonly ApplicationContext _applicationContext;
        public UserAdminController(
            IUserAdminService userAdminService,
            ApplicationContext applicationContext,
            ILogger<UserAdminController> logger)
        {
            _userAdminService = userAdminService;
            _logger = logger;
            _applicationContext = applicationContext;
        }
        [Route("create-user")]
        [HttpPost]
        public async Task<IActionResult> Register(UserAdmin model)
        {
            try
            {
                //var userExists = _userAdminService.CheckUserExists(model.UserName);
                //if (userExists != null)
                //{
                //    return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, ErrorDOMAIN+"tên đăng nhập đã tồn tại" });
                //}
                //else
                //{
                    _userAdminService.CreatedUserAdmin(model);
                    return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error="Tạo tài khoản thành công" });
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi tạo tài khoản: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error="Lỗi tạo tài khoản" });
            }
        }
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = _userAdminService.FindAdminUser(model);
                if (user != null)
                {
                    var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("travisgatesalksdjakljdkjsadfhkjsdfhjksdlfksdljfhsjkdlf-key"))
                                .AddIssuer("JwtRoleBasedAuth")
                                .AddAudience("JwtRoleBasedAuth")
                                .AddExpiry(1)
                                .AddClaim("Name", model.Username)
                                .AddClaim("LastName", user.Result.Password)
                                .AddClaim("RolesId", user.Result.RolesId.ToString())
                                .AddClaim("sub", user.Result.RolesId.ToString())
                                .AddRole("Users")
                                .Build();
                    return Ok(new Result() { Message="success", Code = (int)HttpStatusCode.OK, Data = token.Value, Error = null });
                }
                else
                {
                    return Ok(new Result() { Message="Forbidden", Code = (int)HttpStatusCode.Forbidden, Data="Mật khẩu hoặc user name không đúng", Error = null });
                }
            }
            catch (Exception ex)
            {

                return Ok(new Result() { Message="ServerInternal", Code = (int)HttpStatusCode.InternalServerError, Data="Máy chủ bị lõio", Error = ex.ToString() });
            }
        }
    }
}