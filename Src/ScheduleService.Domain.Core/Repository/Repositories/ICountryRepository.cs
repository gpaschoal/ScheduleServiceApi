using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Repository.Repositories;

public interface ICountryRepository : IRepository<Country>
{
    ValueTask<bool> ExistsCountryWithExternalCodeAsync(string externalCode);
    ValueTask<bool> ExistsCountryWithNameAsync(string name);
    ValueTask<bool> ExistsCountryWithExternalCodeAsync(Guid id, string externalCode);
    ValueTask<bool> ExistsCountryWithNameAsync(Guid id, string name);
    ValueTask<bool> CheckIfIsUsedByState(Guid id);
}
