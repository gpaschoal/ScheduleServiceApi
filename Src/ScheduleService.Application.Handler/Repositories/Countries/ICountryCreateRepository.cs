using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.Handler.Repositories.Countries;

public interface ICountryCreateRepository : ICreateRepository<Country>
{
    bool ExistsCountryWithExternalCode(string externalCode);
    bool ExistsCountryWithName(string name);
}
