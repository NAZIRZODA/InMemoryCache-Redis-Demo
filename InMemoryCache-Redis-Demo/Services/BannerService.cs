using InMemoryCache_Redis_Demo.Models;
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

        var banners = new List<Banner>()
        {
            new Banner()
            {
                Name = "Summer Sale", Title = "Special Discount", Color = "Red",
                Image = "https://example.com/summer_sale.jpg"
            },
            new Banner()
            {
                Name = "New Collection", Title = "Latest Arrivals", Color = "Blue",
                Image = "https://example.com/new_collection.jpg"
            },
            new Banner()
            {
                Name = "Winter Clearance", Title = "Big Savings", Color = "Green",
                Image = "https://example.com/winter_clearance.jpg"
            },
            new Banner()
            {
                Name = "Spring Promotion", Title = "Limited Time Offer", Color = "Yellow",
                Image = "https://example.com/spring_promotion.jpg"
            },
            new Banner()
            {
                Name = "Back to School Sale", Title = "Get Ready for Learning", Color = "Blue",
                Image = "https://example.com/back_to_school.jpg"
            },
            new Banner()
            {
                Name = "Holiday Specials", Title = "Celebrate with Us", Color = "Red",
                Image = "https://example.com/holiday_specials.jpg"
            },
            new Banner()
            {
                Name = "Tech Deals", Title = "Upgrade Your Gadgets", Color = "Orange",
                Image = "https://example.com/tech_deals.jpg"
            },
            new Banner()
            {
                Name = "Fitness Event", Title = "Stay Healthy and Fit", Color = "Purple",
                Image = "https://example.com/fitness_event.jpg"
            }
        };

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