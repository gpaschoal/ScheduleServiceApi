using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Core.Entities.Base;
using ScheduleService.Domain.Repository;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository;

public abstract class RepositoryBase<TEntity>
    : IRepository<TEntity> where TEntity : EntityBase
{
    protected readonly ScheduleServiceDbContext Context;
    private readonly ICacheRepository _cacheRepository;
    protected readonly DbSet<TEntity> Queryable;

    protected RepositoryBase(
        ScheduleServiceDbContext context,
        ICacheRepository cacheRepository)
    {
        Context = context;
        _cacheRepository = cacheRepository;
        Queryable = Context.Set<TEntity>();
    }

    public async ValueTask AddAsync(TEntity data)
    {
        await Context.AddAsync(data);
        await _cacheRepository.SetAsync(data.Id.ToString(), data);
    }

    public async ValueTask DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        ArgumentNullException.ThrowIfNull(entity);
        Context.Remove(entity);
        await _cacheRepository.RemoveAsync(id.ToString());
    }

    public async ValueTask<TEntity?> GetByIdAsync(Guid id)
    {
        var result = await _cacheRepository.TryGetAsync<TEntity?>(id.ToString());

        if (result is not null)
            return result;

        result = await Queryable.FirstOrDefaultAsync(x => x.Id == id);

        await _cacheRepository.SetAsync(id.ToString(), result);

        return result;
    }

    public async ValueTask UpdateAsync(TEntity data)
    {
        Context.Update(data);
        await _cacheRepository.RemoveAsync(data.Id.ToString());
    }

    public ValueTask<bool> CheckIfExistByIdAsync(Guid id)
    {
        var result = Queryable.Any(x => x.Id.Equals(id));
        return ValueTask.FromResult(result);
    }
}
