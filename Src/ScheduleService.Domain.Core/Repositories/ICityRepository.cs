using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories.Base;

namespace ScheduleService.Domain.Core.Repositories;

public interface ICityRepository : IRepository<City>
{
    ValueTask<bool> ExistsCityWithNameAsync(string name);
    ValueTask<bool> ExistsCityWithExternalCodeAsync(string externalCode);
    ValueTask<bool> ExistsCityWithNameAsync(Guid id, string name);
    ValueTask<bool> ExistsCityWithExternalCodeAsync(Guid id, string externalCode);
}
