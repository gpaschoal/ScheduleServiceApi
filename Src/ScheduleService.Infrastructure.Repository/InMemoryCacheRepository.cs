﻿using Microsoft.Extensions.Caching.Memory;
using ScheduleService.Domain.Repository;

namespace ScheduleService.Infrastructure.Repository;

public class InMemoryCacheRepository : ICacheRepository
{
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions? _cacheOptions;

    public InMemoryCacheRepository(
        IMemoryCache memoryCache,
        CacheConfiguration cacheConfig)
    {
        _memoryCache = memoryCache;

        _cacheOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddHours(cacheConfig.AbsoluteExpirationInHours),
            Priority = CacheItemPriority.High,
            SlidingExpiration = TimeSpan.FromMinutes(cacheConfig.SlidingExpirationInMinutes)
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
        return default;
        //_memoryCache.TryGetValue(cacheKey, out var value);

        //return ValueTask.FromResult(value is not null);
    }
}
