namespace RedisDemo.Cache;

public class RedisCacheOptions
{
    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
    
    public bool AllowAdmin { get; set; }
    
    public bool Ssl { get; set; }
    
    public int ConnectTimeout { get; set; }
    
    public int ConnectRetry { get; set; }

    public List<RedisHostOptions> Hosts { get; set; } = new List<RedisHostOptions>();
    
    public bool IsDefault { get; set; }
    
    public int Database { get; set; }
}

public class RedisHostOptions
{
    public string Host { get; set; } = null!;
    
    public int Port { get; set; }
}