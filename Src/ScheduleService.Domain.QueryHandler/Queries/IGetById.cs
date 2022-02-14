namespace ScheduleService.Domain.QueryHandler.Queries;

public interface IGetById<out TResult> : IQuery<TResult>
{
    Guid Id { get; set; }
}
