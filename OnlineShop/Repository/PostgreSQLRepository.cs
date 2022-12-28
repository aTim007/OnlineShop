using OnlineShop.Data;
using OnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Repository
{
    public class PostgreSQLRepository : IProductRepository
    {
        private readonly ProductContext _dbProduct;
        public PostgreSQLRepository(ProductContext context)
        {
            _dbProduct = context;
        }
        public async Task Add(Product item)
        {
            await _dbProduct.Products.AddAsync(item);
            //await _dbProduct.SaveChangesAsync();
        }
        public async Task<IList<Product>> GetAllItem()
        {
            return await _dbProduct.Products.ToListAsync();
        }
        public async Task<Product?> GetItemByName(string key)
        {
            return await _dbProduct.Products.Where(x => x.Name == key).FirstOrDefaultAsync();
        }
    }
}
