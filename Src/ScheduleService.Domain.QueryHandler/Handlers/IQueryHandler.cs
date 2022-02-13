using ScheduleService.Domain.Command.Queries;

namespace ScheduleService.Domain.QueryHandler.Handlers;

public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    ValueTask<TResult> HandleAsync(TQuery query);
}