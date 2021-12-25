using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.Handler.Repositories.Cities;

public interface ICityCreateRepository : ICreateRepository<City>
{
    bool ExistsCityWithName(string name);
    bool ExistsCityWithExternalCode(string externalCode);
}
