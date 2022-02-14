namespace ScheduleService.Domain.QueryHandler.Queries;

public interface IQuery
{ }

public interface IQuery<out TResult> : IQuery
{ }
