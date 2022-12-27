namespace OnlineShop.Repository
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllItem();
        Task Add(T item);
    }
}
