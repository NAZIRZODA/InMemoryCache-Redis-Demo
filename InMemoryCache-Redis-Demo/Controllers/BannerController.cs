using InMemoryCache_Redis_Demo.Models;
using InMemoryCache_Redis_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryCache_Redis_Demo.Controllers;

[ApiController]
[Route("[Controller]")]
public class BannerController : ControllerBase
{
    private readonly IBannerService _bannerService;

    public BannerController(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }

    [HttpGet]
    public async Task<List<Banner>> Get()
    {
        var result = await _bannerService.Get();
        return result;
    }
}