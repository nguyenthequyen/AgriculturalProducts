using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.JwtHelpers;
using AgriculturalProducts.Web.Models;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgriculturalProducts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserClientService _userClientService;
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationContext _applicationContext;
        public AccountController(
            IUserClientService userClientService,
            ApplicationContext applicationContext,
            ILogger<AccountController> logger)
        {
            _userClientService = userClientService;
            _logger = logger;
            _applicationContext = applicationContext;
        }
        [Route("create-user")]
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            try
            {
                var userExists = _userClientService.CheckUserExists(model.UserName);
                if (userExists != null)
                {
                    return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "tên đăng nhập đã tồn tại" });
                }
                else
                {
                    _userClientService.CreatedUserCliet(model);
                    return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Tạo tài khoản thành công" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi tạo tài khoản: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi tạo tài khoản" });
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
                var user = _userClientService.FindClientUser(model);
                if (user != null)
                {
                    var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("travisgatesalksdjakljdkjsadfhkjsdfhjksdlfksdljfhsjkdlf-key"))
                                .AddIssuer("JwtRoleBasedAuth")
                                .AddAudience("JwtRoleBasedAuth")
                                .AddExpiry(1)
                                .AddClaim("Name", model.Username)
                                .AddClaim("LastName", user.Result.LastName)
                                .AddClaim("FirstName", user.Result.FirstName)
                                .AddClaim("RolesId", user.Result.RolesId.ToString())
                                .AddClaim("sub", user.Result.RolesId.ToString())
                                .AddRole("Users")
                                .Build();
                    return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = token.Value, Error = null });
                }
                else
                {
                    return Ok(new Result() { Message = "Forbidden", Code = (int)HttpStatusCode.Forbidden, Data = "Mật khẩu hoặc user name không đúng", Error = null });
                }
            }
            catch (Exception ex)
            {

                return Ok(new Result() { Message = "ServerInternal", Code = (int)HttpStatusCode.InternalServerError, Data = "Máy chủ bị lõio", Error = ex.ToString() });
            }
        }

    }
}