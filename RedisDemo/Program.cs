using RedisDemo.Services;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRedisBannerService, RedisBannerService>();
builder.Services.AddScoped<ICacheService, RedisCacheService>();

builder.Services.Configure<RedisConfiguration>(builder.Configuration.GetSection("RedisCache"));
builder.Services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(_ => new[]
{
    builder.Configuration.GetSection("RedisCache").Get<RedisConfiguration>()!
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();