using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using RedisDemo.Services;

namespace RedisDemo.Controllers;

[ApiController]
[Route("[Controller]")]
public class BannerController : ControllerBase
{
    private readonly IRedisBannerService _bannerService;

    public BannerController(IRedisBannerService bannerService)
    {
        _bannerService = bannerService;
    }

    [HttpGet]
    public async Task<List<Banner>> Get()
    {
       var result = await _bannerService.Get();
       return result;
    }

    [HttpGet("ContainsKey")]
    public async Task<bool> ContainsKey(string key)
    {
        var result = await _bannerService.ContainsKey(key);
        return result;
    }
}