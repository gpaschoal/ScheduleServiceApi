using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories.Base;

namespace ScheduleService.Domain.Core.Repositories;

public interface IStateRepository : IRepository<State>
{
    ValueTask<bool> ExistsStateWithExternalCodeAsync(string externalCode);
    ValueTask<bool> ExistsStateWithNameAsync(string name);
    ValueTask<bool> CheckIfIsUsedByCityAsync(Guid id);
    ValueTask<bool> ExistsStateWithNameAsync(Guid id, string name);
    ValueTask<bool> ExistsStateWithExternalCodeAsync(Guid id, string externalCode);
}
