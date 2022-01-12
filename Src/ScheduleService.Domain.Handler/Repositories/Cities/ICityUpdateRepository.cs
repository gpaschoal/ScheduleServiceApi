using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Handler.Repositories.Cities;

public interface ICityUpdateRepository : IUpdateRepository<City>
{
    bool ExistsCityWithExternalCode(Guid id, string externalCode);
    bool ExistsCityWithName(Guid id, string name);
}
