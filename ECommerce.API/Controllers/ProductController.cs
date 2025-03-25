using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILoggerService _logger;
        public ProductController(ILoggerService logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            _logger.LogInfo("GET all products được gọi");
            var fakeProducts = new[]
            {
                new { Id = 1, Name = "iPhone 15 Pro", Price = 2999 },
                new { Id = 2, Name = "MacBook Air M3", Price = 3999 },
                new { Id = 3, Name = "AirPods Pro", Price = 499 }
            };
            return Ok(fakeProducts);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            _logger.LogInfo($"GET product by id = {id} được gọi");
            var product = new { Id = id, Name = $"Fake Product {id}", Price = 999 };

            return Ok(product);
        }

    }
}
