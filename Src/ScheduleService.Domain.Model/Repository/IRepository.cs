using ScheduleService.Domain.Model.Entities.Base;

namespace ScheduleService.Domain.Model.Repository;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    ValueTask<TEntity?> GetByIdAsync(Guid id);
    ValueTask AddAsync(TEntity data);
    ValueTask UpdateAsync(TEntity data);
    ValueTask DeleteAsync(Guid id);
}
