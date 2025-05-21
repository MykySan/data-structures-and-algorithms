using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Distributed;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost:6379";
            options.InstanceName = "CacheExample";
        });
        var provider = services.BuildServiceProvider();
        var cache = provider.GetRequiredService<IDistributedCache>();
        Console.WriteLine("Redis cache setup complete.");

        var cacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            SlidingExpiration = TimeSpan.FromMinutes(2)
        };

        await cache.SetStringAsync("taskKey", "Sample Task", cacheEntryOptions);
        Console.WriteLine("Cache entry set with absolute and sliding expiration.");
        var cachedValue = await cache.GetStringAsync("taskKey");
        Console.WriteLine(cachedValue != null ? $"Cache hit: {cachedValue}" : "Cache miss: Value expired.");

        Console.WriteLine("Press any key to invalidate cache...");
        Console.ReadKey();
        await InvalidateCache(cache, "taskKey");

        for (int i = 0; i < 5; i++)
        {
            await GetCachedData(cache, "taskKey");
            await Task.Delay(TimeSpan.FromSeconds(10));
        }
    }

    static async Task InvalidateCache(IDistributedCache cache, string key)
    {
        await cache.RemoveAsync(key);
        Console.WriteLine($"Cache entry with key '{key}' invalidated.");
    }

    static async Task<string> GetCachedData(IDistributedCache cache, string key)
    {
        var cachedValue = await cache.GetStringAsync(key);
        if (cachedValue != null)
        {
            Console.WriteLine($"Cache hit: {cachedValue}");
            return cachedValue;
        }

        Console.WriteLine("Cache miss: Fetching new data...");
        var newValue = "Fetched Task Data";
        await cache.SetStringAsync(key, newValue, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            SlidingExpiration = TimeSpan.FromMinutes(2)
        });
        Console.WriteLine("New data cached.");
        return newValue;
    }
}