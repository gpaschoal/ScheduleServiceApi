using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Application.Handler.Repositories;

public interface IDeleteRepository<TEntity> : IHandlerRepository<TEntity> where TEntity : EntityBase
{
    ValueTask DeleteAsync(Guid id);
}
