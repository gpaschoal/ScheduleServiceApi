using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.CommandHandler.Repositories;

public interface IDeleteRepository<TEntity> : IHandlerRepository<TEntity> where TEntity : EntityAudit
{
    ValueTask DeleteAsync(Guid id);
    ValueTask<TEntity?> GetByIdAsync(Guid id);
    ValueTask<bool> CheckIfExistByIdAsync(Guid id);
}
