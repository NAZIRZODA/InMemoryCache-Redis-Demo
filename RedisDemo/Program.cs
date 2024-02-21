using RedisDemo.Cache;
using RedisDemo.Services;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRedisBannerService, RedisBannerService>();
builder.Services.AddScoped<ICacheService, RedisCacheService>();

var redisCacheOptions = builder.Configuration.GetSection("RedisCache").Get<RedisCacheOptions>();
builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
{
    var config = new ConfigurationOptions
    {
        Password = redisCacheOptions!.Password,
        AbortOnConnectFail = false,
        ConnectTimeout = redisCacheOptions.ConnectTimeout,
        Ssl = redisCacheOptions.Ssl,
        AllowAdmin = redisCacheOptions.AllowAdmin
    };

    foreach (var host in redisCacheOptions.Hosts)
    {
        config.EndPoints.Add(host.Host, host.Port);
    }

    return ConnectionMultiplexer.Connect(config);
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