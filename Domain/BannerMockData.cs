using Domain.Models;

namespace Domain;

public static class BannerMockData
{
    public static List<Banner> GetBanners()
    {
        return new List<Banner>()
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
    }
}