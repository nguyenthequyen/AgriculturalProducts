using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturalProducts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IProductService _productService;
        public AccountController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        [Route("insert-product")]
        public async Task<IActionResult> InsertProduct(Product product)
        {
            _productService.InsertProduct(product);
            return Ok();
        }
    }
}