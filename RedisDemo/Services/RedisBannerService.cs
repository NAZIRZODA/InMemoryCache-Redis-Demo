using Domain;
using Domain.Models;

namespace RedisDemo.Services;

public class RedisBannerService : IRedisBannerService
{
    private readonly ICacheService _cacheService;

    public RedisBannerService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<List<Banner>> Get()
    {
       // await _cacheService.RemoveAsync("Banners");
        string key = "Banners";
        var cachedData = await _cacheService.GetAsync<List<Banner>>(key);

        if (cachedData is not null)
        {
            return cachedData;
        }

        var banners = BannerMockData.GetBanners();
        await Task.Delay(2000);

        await _cacheService.SetAsync(key, banners, TimeSpan.FromMinutes(1));

        return banners;
    }

    public async Task<bool> ContainsKey(string key)
    {
        var result = await _cacheService.ContainsKeyAsync(key);
        return result;
    }
}