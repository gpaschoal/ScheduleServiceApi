using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.States;

public interface IStateCreateRepository : ICreateRepository<State>
{
    ValueTask<bool> ExistsStateWithExternalCodeAsync(string externalCode);
    ValueTask<bool> ExistsStateWithNameAsync(string name);
    ValueTask<bool> CheckIfCountryExists(Guid countryId);
}
