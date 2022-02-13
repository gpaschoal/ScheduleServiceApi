using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.CommandHandler.Repositories;

public interface IHandlerRepository<TEntity> where TEntity : EntityAudit
{ }
