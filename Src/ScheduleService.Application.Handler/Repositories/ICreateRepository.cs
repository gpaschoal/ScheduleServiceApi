using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Application.Handler.Repositories;

public interface ICreateRepository<TEntity> : IHandlerRepository<TEntity> where TEntity : EntityBase
{
    ValueTask AddAsync(TEntity data);
}
