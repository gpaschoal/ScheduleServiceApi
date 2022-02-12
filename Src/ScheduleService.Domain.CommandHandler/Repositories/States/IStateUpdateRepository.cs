using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.States;

public interface IStateUpdateRepository : IUpdateRepository<State>
{
    ValueTask<bool> ExistsStateWithNameAsync(Guid id, string name);
    ValueTask<bool> ExistsStateWithExternalCodeAsync(Guid id, string externalCode);
    ValueTask<bool> CheckIfCountryExists(Guid countryId);
}
