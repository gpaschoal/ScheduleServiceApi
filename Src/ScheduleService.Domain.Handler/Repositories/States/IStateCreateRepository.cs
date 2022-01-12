using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Handler.Repositories.States;

public interface IStateCreateRepository : ICreateRepository<State>
{
    bool ExistsStateWithExternalCode(string externalCode);
    bool ExistsStateWithName(string name);
}
