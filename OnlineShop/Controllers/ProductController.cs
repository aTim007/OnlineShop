using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.RabbitMQ;
using OnlineShop.RabbitMQ.Producer;
using OnlineShop.Repository;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _db;
        private readonly RabbitMQProducer _producer;
        public ProductController(IProductRepository dbContext, RabbitMQProducer producer)
        {
            _db = dbContext;
            _producer = producer;
        }
        public async Task<IActionResult> CreateNewProduct(Product product)
        {
            await _db.Add(product);
            _producer.SendMessage(product);
            return Ok(product);
        }
    }
}
