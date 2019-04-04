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
using Microsoft.AspNetCore.Authorization;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAdminController(
            IUserAdminService userAdminService,
            IHttpContextAccessor httpContextAccessor,
            ApplicationContext applicationContext,
            ILogger<UserAdminController> logger)
        {
            _userAdminService = userAdminService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _applicationContext = applicationContext;
        }
        [Route("create-user")]
        [HttpPost]
        public async Task<IActionResult> Register(UserAdmin model)
        {
            try
            {
                var userExists = await _userAdminService.CheckUserExists(model.UserName);
                if (userExists != null)
                {
                    return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "tên đăng nhập đã tồn tại" });
                }
                else
                {
                    _userAdminService.CreatedUserAdmin(model);
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
                var user = await _userAdminService.FindAdminUser(model);
                if (user != null)
                {
                    var rols = await _userAdminService.GetRoles(user.RolesId);
                    var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("travisgatesalksdjakljdkjsadfhkjsdfhjksdlfksdljfhsjkdlf-key"))
                                .AddIssuer("JwtRoleBasedAuth")
                                .AddAudience("JwtRoleBasedAuth")
                                .AddExpiry(1)
                                .AddClaim("Name", model.Username)
                                .AddClaim("LastName", user.Password)
                                .AddClaim("RolesId", user.RolesId.ToString())
                                .AddClaim("sub", user.RolesId.ToString())
                                .AddRole(rols.Name)
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
                _logger.LogError("Lỗi đăng nhập tài khoản: " + ex);
                return Ok(new Result() { Message = "ServerInternal", Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = ex.ToString() });
            }
        }
        [HttpPost]
        [Route("get-users-infor")]
        public async Task<IActionResult> GetUserInfor()
        {
            try
            {
                var claimsIdentity = _httpContextAccessor.HttpContext.User.Claims;
                var data = new UsersInfor();
                var name = claimsIdentity.FirstOrDefault(x => x.Type == "UserName").Value;
                var lastName = claimsIdentity.FirstOrDefault(x => x.Type == "LastName").Value;
                var firstName = claimsIdentity.FirstOrDefault(x => x.Type == "FirstName").Value;
                var email = claimsIdentity.FirstOrDefault(x => x.Type == "Email").Value;
                data.UserName = name;
                data.LastName = lastName;
                data.FirstName = firstName;
                data.Email = email;
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy thông tin tài khoản" + ex);
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = null, Error = "Lỗi lấy thông tin tài khoản" });
            }
        }
        [HttpPost]
        [Route("get-all-user")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
               var data = _userAdminService.GetAllUser();
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy danh sách tài khoản quản trị hệ thống" + ex);
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = null, Error = "Lỗi lấy thông tin tài khoản" });
            }
        }
    }
}