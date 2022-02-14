using ScheduleService.Domain.CommandHandler.Commands;

namespace ScheduleService.Domain.CommandHandler.Handlers;

public interface ICommandHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    ValueTask<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}