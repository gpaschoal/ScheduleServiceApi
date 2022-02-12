using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Countries;

public interface ICountryUpdateRepository : IUpdateRepository<Country>
{
    bool ExistsCountryWithExternalCode(Guid id, string externalCode);
    bool ExistsCountryWithName(Guid id, string name);
}
