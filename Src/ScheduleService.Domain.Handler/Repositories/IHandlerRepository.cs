using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Handler.Repositories;

public interface IHandlerRepository<TEntity> where TEntity : EntityBase
{ }
