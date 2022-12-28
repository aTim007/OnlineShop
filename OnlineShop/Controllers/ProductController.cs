using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.RabbitMQ.Interfaces;
using OnlineShop.RabbitMQ.Producer;
using OnlineShop.Repository;

namespace OnlineShop.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _db;
        private readonly IRabbitMQProducer _producer;
        public ProductController(IProductRepository dbContext, IRabbitMQProducer producer)
        {
            _db = dbContext;
            _producer = producer;
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var product = new Product() { Id = 1, Name = "Product", Price = 10 };
            await _db.Add(product);
            _producer.SendMessage(product);
            return Ok(product);
        }
    }
}
