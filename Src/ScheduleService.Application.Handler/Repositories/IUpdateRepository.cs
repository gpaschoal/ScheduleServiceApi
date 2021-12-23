using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Application.Handler.Repositories;

public interface IUpdateRepository<TEntity> : IHandlerRepository<TEntity> where TEntity : EntityBase
{
    ValueTask UpdateAsync(TEntity data);
}
