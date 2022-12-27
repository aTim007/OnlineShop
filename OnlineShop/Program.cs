using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Data;
using OnlineShop.RabbitMQ;
using OnlineShop.RabbitMQ.Producer;
using OnlineShop.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
builder.Services.AddDbContext<ProductContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, PostgreSQLRepository>();
//builder.Services.AddScoped<IProductRepository, RedisRepository>();
builder.Services.AddScoped<IMessage, RabbitMQProducer>();

builder.Services.AddControllers();

//todo: ошибка при компиляции
var p = new RabbitMQProducer(config);
p.SendMessage("5");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
