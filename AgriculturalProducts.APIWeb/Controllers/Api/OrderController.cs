using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Action = AgriculturalProducts.Models.Action;

namespace AgriculturalProducts.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IStatisticsService _statisticsService;
        public OrderController(
            IUnitOfWork unitOfWork,
            IOrderService orderService,
            IOrderDetailsService orderDetailsService,
            IEmailSenderService emailSenderService,
            StatisticsService statisticsService,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _orderDetailsService = orderDetailsService;
            _httpContextAccessor = httpContextAccessor;
            _emailSenderService = emailSenderService;
            _statisticsService = statisticsService;
        }
        [HttpPost]
        [Route("order-now")]
        [Authorize]
        public async Task<IActionResult> OrderNow(List<OrderDTo> orders)
        {
            try
            {
                var claimsIdentity = _httpContextAccessor.HttpContext.User.Claims;
                var userId = claimsIdentity.FirstOrDefault(x => x.Type == "UserId").Value;
                var email = claimsIdentity.FirstOrDefault(x => x.Type == "Email").Value;
                var orderId = Guid.NewGuid();
                Order order = new Order();
                order.StatusCartsId = Guid.Parse("9C953CAC-1424-43DE-7B60-08D6A7BBDA80");
                order.UserId = Guid.Parse(userId);
                order.Id = orderId;
                _orderService.AddOrder(order);
                List<OrderDetails> orderDetails = new List<OrderDetails>();
                foreach (var item in orders)
                {
                    OrderDetails details = new OrderDetails()
                    {
                        Id = new Guid(),
                        OrderId = orderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        TotalCost = item.TotalCost
                    };
                    orderDetails.Add(details);
                    _orderDetailsService.AddOrderDetails(details);
                }
                _unitOfWork.Commit();
                HttpContext.Session.Clear();
                _emailSenderService.SendEmail(email, Constants.SubjectOrder, Constants.BodyOrder);
                Statistics statistics = new Statistics()
                {
                    Action = (int)Action.Order,
                    ActionName = "Mua hàng",
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    ModifyDate = DateTime.Now
                };
                _statisticsService.InsertStatistics(statistics);
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = "Đặt hàng thành công", Error = null });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = "Đặt hàng thất bại", Error = ex.Message });
            }
        }
    }
}