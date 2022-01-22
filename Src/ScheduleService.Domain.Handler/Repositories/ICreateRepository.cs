using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Handler.Repositories;

public interface ICreateRepository<TEntity> : IHandlerRepository<TEntity> where TEntity : EntityAudit
{
    ValueTask AddAsync(TEntity data);
}
