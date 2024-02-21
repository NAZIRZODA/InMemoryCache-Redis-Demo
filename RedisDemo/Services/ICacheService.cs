namespace RedisDemo.Services;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key);

    Task SetAsync<T>(string key, T value, TimeSpan expirationTime);

    Task<bool> RemoveAsync(string key);

    Task<bool> ContainsKeyAsync(string key);

    Task<T?> GetOrSetAsync<T>(string key, Func<T> func);
}