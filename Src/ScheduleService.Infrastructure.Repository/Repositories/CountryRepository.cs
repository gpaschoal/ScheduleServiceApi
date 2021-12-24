using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }

    public ValueTask<bool> CheckIfIsUsedByState(Guid id)
    {
        var result = Context.Set<State>().Any(x => x.CountryId.Equals(id));
        return ValueTask.FromResult(result);
    }

    public bool ExistsCountryWithExternalCode(string externalCode)
    {
        var result = Queryable.Any(x => x.ExternalCode.Equals(externalCode));
        return result;
    }

    public bool ExistsCountryWithExternalCode(Guid id, string externalCode)
    {
        var result = Queryable.Any(x => !x.Id.Equals(id) && x.ExternalCode.Equals(externalCode));
        return result;
    }

    public bool ExistsCountryWithName(string name)
    {
        var result = Queryable.Any(x => x.Name.Equals(name));
        return result;
    }

    public bool ExistsCountryWithName(Guid id, string name)
    {
        var result = Queryable.Any(x => !x.Id.Equals(id) && x.Name.Equals(name));
        return result;
    }
}
