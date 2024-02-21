using Domain.Models;

namespace InMemoryCache_Redis_Demo.Services;

public interface IBannerService
{
    Task<List<Banner>> Get();
}