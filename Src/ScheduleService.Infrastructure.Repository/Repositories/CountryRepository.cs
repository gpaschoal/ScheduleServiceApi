using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;
using ScheduleService.Domain.Core.Repositories.Base;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

internal class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(AppDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }

    public async ValueTask<bool> CheckIfIsUsedByState(Guid id)
    {
        var result = await Context.Set<State>().AnyAsync(x => x.CountryId.Equals(id));
        return result;
    }

    public async ValueTask<bool> ExistsCountryWithExternalCodeAsync(string externalCode)
    {
        var result = await Queryable.AnyAsync(x => x.ExternalCode.Equals(externalCode));
        return result;
    }

    public async ValueTask<bool> ExistsCountryWithExternalCodeAsync(Guid id, string externalCode)
    {
        var result = await Queryable.AnyAsync(x => !x.Id.Equals(id) && x.ExternalCode.Equals(externalCode));
        return result;
    }

    public async ValueTask<bool> ExistsCountryWithNameAsync(string name)
    {
        var result = await Queryable.AnyAsync(x => x.Name.Equals(name));
        return result;
    }

    public async ValueTask<bool> ExistsCountryWithNameAsync(Guid id, string name)
    {
        var result = await Queryable.AnyAsync(x => !x.Id.Equals(id) && x.Name.Equals(name));
        return result;
    }
}
