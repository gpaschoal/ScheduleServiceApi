namespace ScheduleService.Domain.Command.Queries;

public interface IQuery
{ }

public interface IQuery<out TResult> : IQuery
{ }
