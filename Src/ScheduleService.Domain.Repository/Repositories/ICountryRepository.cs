using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Repository.Repositories;

public interface ICountryRepository : IRepository<Country>
{
    bool ExistsCountryWithExternalCode(string externalCode);
    bool ExistsCountryWithName(string name);
    bool ExistsCountryWithExternalCode(Guid id, string externalCode);
    bool ExistsCountryWithName(Guid id, string name);
    ValueTask<bool> CheckIfIsUsedByState(Guid id);
}
