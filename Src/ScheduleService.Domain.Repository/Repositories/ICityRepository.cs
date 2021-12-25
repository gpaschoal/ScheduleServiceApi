using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Repository.Repositories;

public interface ICityRepository : IRepository<City>
{
    bool ExistsCityWithName(string name);
    bool ExistsCityWithExternalCode(string externalCode);
    bool ExistsCityWithName(Guid id, string name);
    bool ExistsCityWithExternalCode(Guid id, string externalCode);
}
