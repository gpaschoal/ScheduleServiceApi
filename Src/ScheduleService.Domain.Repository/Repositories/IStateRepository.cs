using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Repository.Repositories;

public interface IStateRepository : IRepository<State>
{
    bool ExistsStateWithExternalCode(string externalCode);
    bool ExistsStateWithName(string name);
    ValueTask<bool> CheckIfIsUsedByCity(Guid id);
    bool ExistsStateWithName(Guid id, string name);
    bool ExistsStateWithExternalCode(Guid id, string externalCode);
}
