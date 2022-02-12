using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Cities;

public interface ICityCreateRepository : ICreateRepository<City>
{
    bool ExistsCityWithName(string name);
    bool ExistsCityWithExternalCode(string externalCode);
}
