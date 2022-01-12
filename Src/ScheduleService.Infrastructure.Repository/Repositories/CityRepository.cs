using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

internal class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }

    public bool ExistsCityWithExternalCode(string externalCode)
    {
        var result = Queryable.Any(x => x.ExternalCode.Equals(externalCode));
        return result;
    }

    public bool ExistsCityWithExternalCode(Guid id, string externalCode)
    {
        var result = Queryable.Any(x => x.Id.Equals(id) && x.ExternalCode.Equals(externalCode));
        return result;
    }

    public bool ExistsCityWithName(string name)
    {
        var result = Queryable.Any(x => x.Name.Equals(name));
        return result;
    }

    public bool ExistsCityWithName(Guid id, string name)
    {
        var result = Queryable.Any(x => x.Id.Equals(id) && x.Name.Equals(name));
        return result;
    }
}
