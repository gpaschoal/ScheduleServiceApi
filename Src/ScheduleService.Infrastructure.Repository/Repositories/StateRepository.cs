using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

public class StateRepository : RepositoryBase<State>, IStateRepository
{
    public StateRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }

    public ValueTask<bool> CheckIfIsUsedByCity(Guid id)
    {
        var result = Context.Set<City>().Any(x => x.StateId.Equals(id));
        return ValueTask.FromResult(result);
    }

    public bool ExistsStateWithExternalCode(string externalCode)
    {
        var result = Queryable.Any(x => x.ExternalCode.Equals(externalCode));
        return result;
    }

    public bool ExistsStateWithExternalCode(Guid id, string externalCode)
    {
        var result = Queryable.Any(x => !x.Id.Equals(id) && x.ExternalCode.Equals(externalCode));
        return result;
    }

    public bool ExistsStateWithName(string name)
    {
        var result = Queryable.Any(x => x.Name.Equals(name));
        return result;
    }

    public bool ExistsStateWithName(Guid id, string name)
    {
        var result = Queryable.Any(x => !x.Id.Equals(id) && x.Name.Equals(name));
        return result;
    }
}
