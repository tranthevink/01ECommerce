using ECommerce.Application.Interfaces;
using ECommerce.Application.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILoggerService _logger;
        private readonly IMediator _mediator;
        public ProductController(ILoggerService logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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
        public async Task<IActionResult> GetProductByIdAsync(Guid id)
        {
            _logger.LogInfo($"GET product by id = {id} is called");
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
