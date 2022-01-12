using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Handler.Repositories;

public interface IDeleteRepository<TEntity> : IHandlerRepository<TEntity> where TEntity : EntityBase
{
    ValueTask DeleteAsync(Guid id);
    ValueTask<TEntity?> GetByIdAsync(Guid id);
    ValueTask<bool> CheckIfExistByIdAsync(Guid id);
}
