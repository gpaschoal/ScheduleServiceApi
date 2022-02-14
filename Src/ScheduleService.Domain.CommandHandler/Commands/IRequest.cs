namespace ScheduleService.Domain.CommandHandler.Commands;

public interface IRequest { }

public interface IRequest<out TResponse> : IRequest
{ }