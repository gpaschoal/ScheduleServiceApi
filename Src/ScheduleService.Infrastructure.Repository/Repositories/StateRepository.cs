using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

internal class StateRepository : RepositoryBase<State>, IStateRepository
{
    public StateRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }

    public async ValueTask<bool> CheckIfIsUsedByCityAsync(Guid id)
    {
        var result = await Context.Set<City>().AnyAsync(x => x.StateId.Equals(id));
        return result;
    }

    public async ValueTask<bool> ExistsStateWithExternalCodeAsync(string externalCode)
    {
        var result = await Queryable.AnyAsync(x => x.ExternalCode.Equals(externalCode));
        return result;
    }

    public async ValueTask<bool> ExistsStateWithExternalCodeAsync(Guid id, string externalCode)
    {
        var result = await Queryable.AnyAsync(x => !x.Id.Equals(id) && x.ExternalCode.Equals(externalCode));
        return result;
    }

    public async ValueTask<bool> ExistsStateWithNameAsync(string name)
    {
        var result = await Queryable.AnyAsync(x => x.Name.Equals(name));
        return result;
    }

    public async ValueTask<bool> ExistsStateWithNameAsync(Guid id, string name)
    {
        var result = await Queryable.AnyAsync(x => !x.Id.Equals(id) && x.Name.Equals(name));
        return result;
    }
}
