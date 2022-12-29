namespace OnlineShop.Redis
{
    public interface ICache
    {
        Task<T> Get<T>(string key);
        Task<bool> Set<T>(string key, T value);
        Task<bool> Delete<T>(string key);
    }
}
