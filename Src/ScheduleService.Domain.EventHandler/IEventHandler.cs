namespace ScheduleService.Domain.EventHandler;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    ValueTask HandleAsync(TEvent request, CancellationToken cancellationToken);
}
