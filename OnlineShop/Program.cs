using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using OnlineShop.Data;
using OnlineShop.RabbitMQ;
using OnlineShop.Redis;
using OnlineShop.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
builder.Services.AddDbContext<ProductContext>(options => options.UseNpgsql(config.GetConnectionString("PostgreSQL")));
builder.Services.AddScoped<IProductRepository, PostgreSQLRepository>();
//builder.Services.AddScoped<IProductRepository, RedisRepository>();
builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
builder.Services.AddScoped<ICache, CacheManager>();

builder.Services.AddControllers();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();;
