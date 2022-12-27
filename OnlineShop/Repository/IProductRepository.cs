using OnlineShop.Models;
using Redis.OM.Searching;

namespace OnlineShop.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IList<Product>> GetAllItem();
    }
}
