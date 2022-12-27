using OnlineShop.Data;
using OnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Redis;
using Redis.OM.Searching;
using Redis.OM;
using System.Collections;

namespace OnlineShop.Repository
{
    public class RedisRepository : IProductRepository
    {
        private readonly RedisCollection<Product> _dbProduct;
        private readonly RedisConnectionProvider _provider;
        public RedisRepository(RedisConnectionProvider provider)
        {
            _provider = provider;
            _dbProduct = (RedisCollection<Product>)provider.RedisCollection<Product>();
        }
        public async Task Add(Product item)
        {
            await _dbProduct.InsertAsync(item);
            await _dbProduct.SaveAsync();
        }
        public async Task<IList<Product>> GetAllItem()
        {
            return await _dbProduct.ToListAsync();
        }
        public async Task<Product?> GetItemByName(string key)
        {
            return await _dbProduct.Where(x => x.ProductName == key).FirstOrDefaultAsync();
        }
    }
}
