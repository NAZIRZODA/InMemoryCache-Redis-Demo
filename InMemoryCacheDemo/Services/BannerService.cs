using Domain;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache_Redis_Demo.Services;

public class BannerService : IBannerService
{
    private readonly IMemoryCache _memoryCache;

    public BannerService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task<List<Banner>> Get()
    {
        var cachedBanners = _memoryCache.Get<List<Banner>>("Banners");
        if (cachedBanners is not null)
        {
            return cachedBanners;
        }

        var banners = BannerMockData.GetBanners();

        await Task.Delay(2000);

        MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(40),
            SlidingExpiration = TimeSpan.FromSeconds(10)
        };
        
        _memoryCache.Set<List<Banner>>("Banners", banners, options);
        return banners;
    }
}