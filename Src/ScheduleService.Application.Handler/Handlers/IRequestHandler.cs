using ScheduleService.Application.Command.Commands;

namespace ScheduleService.Application.Handler.Handlers;

public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}