using Microsoft.Extensions.Options;
using ScheduleService.Domain.Core.Repositories.Base;
using ServiceStack.Redis;

namespace ScheduleService.Infrastructure.Repository;

public class RedisCacheRepository : ICacheRepository
{
    private readonly IRedisClientsManagerAsync _manager;

    private readonly CacheConfiguration _cacheConfig;

    public RedisCacheRepository(
        IOptions<CacheConfiguration> cacheConfig,
        IRedisClientsManagerAsync manager
    )
    {
        _cacheConfig = cacheConfig.Value;
        _manager = manager;
    }

    public async ValueTask RemoveAsync(string cacheKey)
    {
        var client = await _manager.GetClientAsync();

        await client.RemoveAsync(cacheKey);
    }

    public async ValueTask<T> SetAsync<T>(string cacheKey, T value)
    {
        var client = await _manager.GetClientAsync();

        await client.SetAsync(cacheKey, value, TimeSpan.FromMinutes(_cacheConfig.SlidingExpirationInMinutes * 100000));

        return value;
    }

    public async ValueTask<T> TryGetAsync<T>(string cacheKey)
    {
        var client = await _manager.GetClientAsync();

        var value = await client.GetAsync<T>(cacheKey);

        return value;
    }
}