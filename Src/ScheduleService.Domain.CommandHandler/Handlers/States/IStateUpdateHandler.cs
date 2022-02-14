using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.States;

namespace ScheduleService.Domain.CommandHandler.Handlers.States;

public interface IStateUpdateHandler : ICommandHandler<StateUpdateCommand, CustomResultData>
{ }
