using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.RabbitMQ.Interfaces;
using OnlineShop.RabbitMQ.Producer;
using OnlineShop.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
builder.Services.AddDbContext<ProductContext>(options => options.UseNpgsql(config.GetConnectionString("PostgreSQL")));
builder.Services.AddScoped<IProductRepository, PostgreSQLRepository>();
//builder.Services.AddScoped<IProductRepository, RedisRepository>();
builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
