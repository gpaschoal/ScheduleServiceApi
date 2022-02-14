namespace ScheduleService.Domain.Core.Repositories.Base;

public interface ICacheRepository
{
    ValueTask<T> TryGetAsync<T>(string cacheKey);
    ValueTask<T> SetAsync<T>(string cacheKey, T value);
    ValueTask RemoveAsync(string cacheKey);
}
