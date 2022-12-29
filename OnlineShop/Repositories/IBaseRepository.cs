namespace OnlineShop.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetItemByName(string name);
        Task Add(T item);
    }
}
