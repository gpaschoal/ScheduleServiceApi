namespace ScheduleService.Domain.Command.Commands;

public interface IRequest { }

public interface IRequest<out TResponse> : IRequest
{ }