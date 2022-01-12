using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Handler.Repositories;

public interface IUpdateRepository<TEntity> : IHandlerRepository<TEntity> where TEntity : EntityBase
{
    ValueTask UpdateAsync(TEntity data);
    ValueTask<TEntity?> GetByIdAsync(Guid id);
}
