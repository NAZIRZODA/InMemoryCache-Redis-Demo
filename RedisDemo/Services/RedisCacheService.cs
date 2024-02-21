using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisDemo.Services;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _db;

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _db = connectionMultiplexer.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var data = await _db.StringGetAsync(key);

        if (!string.IsNullOrEmpty(data))
        {
            return JsonConvert.DeserializeObject<T>(data!);
        }

        return default;
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expirationTimeSpan)
    {
        var jsonString = JsonConvert.SerializeObject(value);
        await _db.StringSetAsync(key, jsonString, expirationTimeSpan);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        var isDeleted = await _db.KeyDeleteAsync(key);
        return isDeleted;
    }

    public async Task<bool> ContainsKeyAsync(string key)
    {
        var isExist = await _db.KeyExistsAsync(key);
        return isExist;
    }

    public async Task<T?> GetOrSetAsync<T>(string key, Func<T> func)
    {
        var isKeyExist = await _db.KeyExistsAsync(key);
        if (isKeyExist)
        {
            var result = await _db.StringGetAsync(key);
            return JsonConvert.DeserializeObject<T>(result!);
        }

        var data = func();
        await _db.StringSetAsync(key, JsonConvert.SerializeObject(data));

        return data;
    }
}