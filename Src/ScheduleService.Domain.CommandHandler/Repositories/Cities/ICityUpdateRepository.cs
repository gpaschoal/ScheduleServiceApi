using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Cities;

public interface ICityUpdateRepository : IUpdateRepository<City>
{
    bool ExistsCityWithExternalCode(Guid id, string externalCode);
    bool ExistsCityWithName(Guid id, string name);
}
