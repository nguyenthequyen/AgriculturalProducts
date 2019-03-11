using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using AgriculturalProducts.Services;
using AgriculturalProducts.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public OrderController(
            IUnitOfWork unitOfWork,
            IOrderService orderService,
            IOrderDetailsService orderDetailsService,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _orderDetailsService = orderDetailsService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        [Route("order-now")]
        public async Task<IActionResult> OrderNow(List<OrderDTo> orders)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Claims;
            var userId = claimsIdentity.FirstOrDefault(x => x.Type == "UserId").Value;
            var orderId = new Guid();
            Order order = new Order();
            order.UserId = Guid.Parse(userId);
            order.Id = orderId;
            _orderService.AddOrder(order);
            _unitOfWork.Commit();
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
            return Ok();
        }
    }
}