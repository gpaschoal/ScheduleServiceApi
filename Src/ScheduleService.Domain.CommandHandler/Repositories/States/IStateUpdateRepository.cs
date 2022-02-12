using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.States;

public interface IStateUpdateRepository : IUpdateRepository<State>
{
    bool ExistsStateWithName(Guid id, string name);
    bool ExistsStateWithExternalCode(Guid id, string externalCode);
    ValueTask<bool> CheckIfCountryExists(Guid countryId);
}
