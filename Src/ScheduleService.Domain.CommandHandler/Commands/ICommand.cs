using ScheduleService.Application.Shared;

namespace ScheduleService.Domain.CommandHandler.Commands;

public interface ICommandExecution<T> : IRequest<CustomResultData<T>> where T : new()
{ }

public interface ICommandExecution : IRequest<CustomResultData>
{ }
