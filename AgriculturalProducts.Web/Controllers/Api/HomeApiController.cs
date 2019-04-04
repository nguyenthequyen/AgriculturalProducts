using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AgriculturalProducts.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private readonly ILogger<HomeApiController> _logger;
        public HomeApiController(ILogger<HomeApiController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("secure-website")]
        public async Task<IActionResult> SecureWebsite(SecureGoogle secure)
        {
            try
            {
                var secretKey = "6LcByJcUAAAAAJY7cindNFutYwsQjUUn_14cSubD";
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.PostAsync("https://www.google.com/recaptcha/api/siteverify?secret=" + secretKey + "&response=" + secure.Token, null);
                    if (result.IsSuccessStatusCode)
                    {
                        string resultContent = await result.Content.ReadAsStringAsync();
                        dynamic obj = JsonConvert.DeserializeObject(resultContent);
                        if (obj.score >= 0.5 && obj.action == "homepage" && obj.success == true)
                        {
                            _logger.LogError(resultContent);
                            return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "success", Error = null, Message = null });
                        }
                        else
                        {
                            _logger.LogError("Trang web của bạn đang bị tấn công");
                            return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "error", Error = null, Message = null });
                        }
                    }
                    else
                    {
                        return Ok(new Result() { Code = (int)HttpStatusCode.OK, Data = "error", Error = null, Message = null });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi gửi request lên Google: " + ex);
                return Ok(new Result() { Code = (int)HttpStatusCode.InternalServerError, Data = null, Error = ex.Message, Message = null });
            }
        }
    }
}