namespace ScheduleService.Infrastructure.Repository;

public record CacheConfiguration(int AbsoluteExpirationInHours, int SlidingExpirationInMinutes);
