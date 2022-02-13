using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Repository.Repositories;

public interface ICityRepository : IRepository<City>
{
    ValueTask<bool> ExistsCityWithNameAsync(string name);
    ValueTask<bool> ExistsCityWithExternalCodeAsync(string externalCode);
    ValueTask<bool> ExistsCityWithNameAsync(Guid id, string name);
    ValueTask<bool> ExistsCityWithExternalCodeAsync(Guid id, string externalCode);
}
