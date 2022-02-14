using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories.Base;

namespace ScheduleService.Domain.Core.Repositories;

public interface ICountryRepository : IRepository<Country>
{
    ValueTask<bool> ExistsCountryWithExternalCodeAsync(string externalCode);
    ValueTask<bool> ExistsCountryWithNameAsync(string name);
    ValueTask<bool> ExistsCountryWithExternalCodeAsync(Guid id, string externalCode);
    ValueTask<bool> ExistsCountryWithNameAsync(Guid id, string name);
    ValueTask<bool> CheckIfIsUsedByState(Guid id);
}
