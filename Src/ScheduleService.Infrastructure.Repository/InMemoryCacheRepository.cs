using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ScheduleService.Domain.Core.Repositories.Base;

namespace ScheduleService.Infrastructure.Repository;

public class InMemoryCacheRepository : ICacheRepository
{
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions? _cacheOptions;

    public InMemoryCacheRepository(
        IMemoryCache memoryCache,
        IOptions<CacheConfiguration> cacheConfig)
    {
        _memoryCache = memoryCache;

        _cacheOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddHours(cacheConfig.Value.AbsoluteExpirationInHours),
            Priority = CacheItemPriority.High,
            SlidingExpiration = TimeSpan.FromMinutes(cacheConfig.Value.SlidingExpirationInMinutes)
        };
    }

    public ValueTask RemoveAsync(string cacheKey)
    {
        _memoryCache.Remove(cacheKey);
        return ValueTask.CompletedTask;
    }

    public ValueTask<T> SetAsync<T>(string cacheKey, T value)
    {
        return ValueTask.FromResult(_memoryCache.Set(cacheKey, value, _cacheOptions));
    }

    public ValueTask<T> TryGetAsync<T>(string cacheKey)
    {
        _memoryCache.TryGetValue<T>(cacheKey, out var value);

        return ValueTask.FromResult(value);
    }
}
