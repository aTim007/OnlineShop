using OnlineShop.Models;

namespace OnlineShop.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> GetItemByName(string name);
    }
}
