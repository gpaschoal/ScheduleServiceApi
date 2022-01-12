using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Handler.Repositories.Countries;

public interface ICountryCreateRepository : ICreateRepository<Country>
{
    bool ExistsCountryWithExternalCode(string externalCode);
    bool ExistsCountryWithName(string name);
}
