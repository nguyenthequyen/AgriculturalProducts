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
using Microsoft.Extensions.Logging;
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
        private readonly IProductClientService _productClientService;
        private readonly IStatusCartsService _statusCartsService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(
            IUnitOfWork unitOfWork,
            IOrderService orderService,
            IOrderDetailsService orderDetailsService,
            IEmailSenderService emailSenderService,
            ILogger<OrderController> logger,
            IProductClientService productClientService,
            IStatusCartsService statusCartsService,
            IStatisticsService statisticsService,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _orderDetailsService = orderDetailsService;
            _httpContextAccessor = httpContextAccessor;
            _emailSenderService = emailSenderService;
            _statisticsService = statisticsService;
            _logger = logger;
            _productClientService = productClientService;
            _statusCartsService = statusCartsService;
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
                var statusProduct = _statusCartsService.GetStatusCartsClient();
                var orderId = Guid.NewGuid();
                Order order = new Order();
                order.UserId = Guid.Parse(userId);
                order.Id = orderId;
                List<OrderDetails> orderDetails = new List<OrderDetails>();
                List<ProductOrder> productOrders = new List<ProductOrder>();
                var total = 0; var totalCost = 0f;
                foreach (var item in orders)
                {
                    OrderDetails details = new OrderDetails()
                    {
                        Id = new Guid(),
                        OrderId = orderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        TotalCost = item.TotalCost,
                        StatusCartId = statusProduct.Id
                    };
                    totalCost += item.TotalCost;
                    total += item.Quantity;
                    _orderDetailsService.AddOrderDetails(details);
                    orderDetails.Add(details);
                }
                order.TotalQuantity = total;
                order.TotalCost = totalCost;
                order.Processed = 0;
                _orderService.AddOrder(order);
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
                _logger.LogError("Đặt hàng thất bại: " + ex);
                return Ok(new Result() { Message = "success", Code = (int)HttpStatusCode.OK, Data = null, Error = "Đặt hàng thất bại" });
            }
        }
    }
}