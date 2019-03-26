using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.JwtHelpers;
using AgriculturalProducts.Web.Models;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Action = AgriculturalProducts.Models.Action;

namespace AgriculturalProducts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserClientService _userClientService;
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationContext _applicationContext;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IStatisticsService _statisticsService;
        private readonly IRolesService _rolesService;
        public AccountController(
            IUserClientService userClientService,
            ApplicationContext applicationContext,
            IHttpContextAccessor httpContextAccessor,
            IEmailSenderService emailSenderService,
            IStatisticsService statisticsService,
            IRolesService rolesService,
            ILogger<AccountController> logger)
        {

            _userClientService = userClientService;
            _logger = logger;
            _applicationContext = applicationContext;
            _httpContextAccessor = httpContextAccessor;
            _emailSenderService = emailSenderService;
            _statisticsService = statisticsService;
            _rolesService = rolesService;
        }
        [Route("create-user")]
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            try
            {
                var roles = _rolesService.GetRolesClient();
                model.RolesId = roles.Id;
                _userClientService.CreatedUserCliet(model);
                _emailSenderService.SendEmail(model.Email, Constants.SubjectCreatedAccount, Constants.BodyCreatedAccount);
                Statistics statistics = new Statistics()
                {
                    Action = (int)Action.CreatedUser,
                    ActionName = "Đăng ký tài khoản",
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    ModifyDate = DateTime.Now
                };
                _statisticsService.InsertStatistics(statistics);
                _logger.LogError("Đăng ký tài khoản thành công");
                return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = null, Error = "Tạo tài khoản thành công" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi tạo tài khoản: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = "Lỗi tạo tài khoản" });
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = await _userClientService.FindClientUser(model);
                if (user != null)
                {
                    var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("travisgatesalksdjakljdkjsadfhkjsdfhjksdlfksdljfhsjkdlf-key"))
                                .AddIssuer("JwtRoleBasedAuth")
                                .AddAudience("JwtRoleBasedAuth")
                                .AddExpiry(1)
                                .AddClaim("UserName", model.Username)
                                .AddClaim("Email", user.Email)
                                .AddClaim("LastName", user.LastName)
                                .AddClaim("FirstName", user.FirstName)
                                .AddClaim("RolesId", user.RolesId.ToString())
                                .AddClaim("UserId", user.Id.ToString())
                                .AddRole("Users")
                                .Build();
                    Statistics statistics = new Statistics()
                    {
                        Action = (int)Action.Login,
                        ActionName = "Đăng nhập vào hệ thống",
                        CreatedDate = DateTime.Now,
                        Id = Guid.NewGuid(),
                        ModifyDate = DateTime.Now
                    };
                    _statisticsService.InsertStatistics(statistics);
                    _logger.LogError("Đăng nhập thành công");
                    return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = token.Value, Error = null });
                }
                else
                {
                    _logger.LogError("Lỗi tài khoản hoặc mật khẩu không đúng");
                    return Ok(new Result() { Message = "Forbidden", Code = (int)HttpStatusCode.Forbidden, Data = null, Error = null });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi tài khoản hoặc mật khẩu không đúng" + ex);
                return Ok(new Result() { Message = "ServerInternal", Code = (int)HttpStatusCode.InternalServerError, Data = "Máy chủ bị lỗi", Error = ex.ToString() });
            }
        }
        [HttpPost]
        [Route("get-users-infor")]
        [Authorize]
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
                _logger.LogError("Lấy thông tin tài khoản thành công");
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = data, Error = null });
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi lấy thông tin tài khoản" + ex);
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = null, Error = "Lỗi lấy thông tin tài khoản" });
            }
        }
    }
}