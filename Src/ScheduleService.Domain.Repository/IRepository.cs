using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Repository;

public interface IRepository<TEntity> where TEntity : EntityAudit
{
    ValueTask<TEntity?> GetByIdAsync(Guid id);
    ValueTask AddAsync(TEntity data);
    ValueTask UpdateAsync(TEntity data);
    ValueTask DeleteAsync(Guid id);
    ValueTask<bool> CheckIfExistByIdAsync(Guid id);
}
