using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

internal class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }

    public async ValueTask<bool> ExistsCityWithExternalCodeAsync(string externalCode)
    {
        var result = await Queryable.AnyAsync(x => x.ExternalCode.Equals(externalCode));
        return result;
    }

    public async ValueTask<bool> ExistsCityWithExternalCodeAsync(Guid id, string externalCode)
    {
        var result = await Queryable.AnyAsync(x => x.Id.Equals(id) && x.ExternalCode.Equals(externalCode));
        return result;
    }

    public async ValueTask<bool> ExistsCityWithNameAsync(string name)
    {
        var result = await Queryable.AnyAsync(x => x.Name.Equals(name));
        return result;
    }

    public async ValueTask<bool> ExistsCityWithNameAsync(Guid id, string name)
    {
        var result = await Queryable.AnyAsync(x => x.Id.Equals(id) && x.Name.Equals(name));
        return result;
    }
}
