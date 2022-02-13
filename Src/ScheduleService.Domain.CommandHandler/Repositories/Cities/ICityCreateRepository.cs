using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Cities;

public interface ICityCreateRepository : ICreateRepository<City>
{
    ValueTask<bool> ExistsCityWithNameAsync(string name);
    ValueTask<bool> ExistsCityWithExternalCodeAsync(string externalCode);
    ValueTask<bool> CheckIfStateExists(Guid countryId);
}
