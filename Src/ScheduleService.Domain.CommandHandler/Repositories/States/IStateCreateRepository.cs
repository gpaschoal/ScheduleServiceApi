using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.States;

public interface IStateCreateRepository : ICreateRepository<State>
{
    bool ExistsStateWithExternalCode(string externalCode);
    bool ExistsStateWithName(string name);
    ValueTask<bool> CheckIfCountryExists(Guid countryId);
}
