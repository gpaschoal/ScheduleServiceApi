using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Cities;

public interface ICityUpdateRepository : IUpdateRepository<City>
{
    ValueTask<bool> ExistsCityWithExternalCodeAsync(Guid id, string externalCode);
    ValueTask<bool> ExistsCityWithNameAsync(Guid id, string name);
    ValueTask<bool> CheckIfStateExists(Guid countryId);
}
