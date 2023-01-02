using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;
            
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get() {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 4", Price = 400,CreatedDate =DateTime.UtcNow, Stock= 40 },
                new() {Id = Guid.NewGuid(), Name = "Product 5", Price = 500,CreatedDate =DateTime.UtcNow, Stock= 50 },
                new() {Id = Guid.NewGuid(), Name = "Product 6", Price = 600,CreatedDate =DateTime.UtcNow, Stock= 60 },
            });
            await _productWriteRepository.SaveAsync();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
           Product product=  await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
