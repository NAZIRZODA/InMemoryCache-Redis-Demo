using Domain.Models;

namespace RedisDemo.Services;

public interface IRedisBannerService
{
    Task<List<Banner>> Get();
    
    Task<bool> ContainsKey(string key);
}