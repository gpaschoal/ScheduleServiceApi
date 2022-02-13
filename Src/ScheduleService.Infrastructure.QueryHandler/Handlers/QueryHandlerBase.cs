using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Core.Entities.Base;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.QueryHandler.Handlers;

internal abstract class QueryHandlerBase<TEntity> where TEntity : EntityAudit
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<TEntity> Queryable;

    protected QueryHandlerBase(AppDbContext context)
    {
        Context = context;
        Queryable = Context.Set<TEntity>();
    }
}
