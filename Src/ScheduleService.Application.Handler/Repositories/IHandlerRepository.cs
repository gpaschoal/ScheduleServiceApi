using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Application.Handler.Repositories;

public interface IHandlerRepository<TEntity> where TEntity : EntityBase
{ }
