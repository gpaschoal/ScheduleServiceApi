namespace ScheduleService.Domain.Repository;

public interface ICacheRepository
{
    ValueTask<T> TryGetAsync<T>(string cacheKey);
    ValueTask<T> SetAsync<T>(string cacheKey, T value);
    ValueTask RemoveAsync(string cacheKey);
}
