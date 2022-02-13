using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Countries;

public interface ICountryCreateRepository : ICreateRepository<Country>
{
    ValueTask<bool> ExistsCountryWithExternalCodeAsync(string externalCode);
    ValueTask<bool> ExistsCountryWithName(string name);
}
