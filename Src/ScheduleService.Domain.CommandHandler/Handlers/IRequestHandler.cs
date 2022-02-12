using ScheduleService.Domain.Command.Commands;

namespace ScheduleService.Domain.CommandHandler.Handlers;

public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
}