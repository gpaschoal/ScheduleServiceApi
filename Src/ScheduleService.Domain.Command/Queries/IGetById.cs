namespace ScheduleService.Domain.Command.Queries;

public interface IGetById<out TResult> : IQuery<TResult>
{
    Guid Id { get; set; }
}
