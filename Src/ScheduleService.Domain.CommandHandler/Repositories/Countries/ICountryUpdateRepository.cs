using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Countries;

public interface ICountryUpdateRepository : IUpdateRepository<Country>
{
    ValueTask<bool> ExistsCountryWithExternalCodeAsync(Guid id, string externalCode);
    ValueTask<bool> ExistsCountryWithNameAsync(Guid id, string name);
}
