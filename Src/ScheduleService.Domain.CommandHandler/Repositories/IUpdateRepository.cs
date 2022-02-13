using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.CommandHandler.Repositories;

public interface IUpdateRepository<TEntity> : IHandlerRepository<TEntity> where TEntity : EntityAudit
{
    ValueTask UpdateAsync(TEntity data);
    ValueTask<TEntity?> GetByIdAsync(Guid id);
}
