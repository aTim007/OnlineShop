using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OnlineShop.Models;
using OnlineShop.Repository;
using Redis.OM;
using Redis.OM.Contracts;
using Redis.OM.Searching;
using StackExchange.Redis;

namespace OnlineShop.Redis
{
    public class CacheManager : ICache
    {
        private readonly IDatabase _db;
        public CacheManager(IConfiguration config)
        {
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(config.GetSection("RedisConnection").Value);
            _db = conn.GetDatabase(0);
        }
        public async Task<bool> Delete<T>(string key)
        {
            bool exist = await _db.KeyExistsAsync(key);
            if (exist)
            {
                return _db.KeyDeleteAsync(key).Result;
            }   
            return false;
        }

        public async Task<T> Get<T>(string key)
        {
            var obj = await _db.StringGetAsync(key);
            if (!string.IsNullOrEmpty(obj))
            {
                return JsonConvert.DeserializeObject<T>(obj);
            }
            return default;
        }

        public Task<bool> Set<T>(string key, T value)
        {
            return _db.StringSetAsync(key, JsonConvert.SerializeObject(value));
        }
    }
}
