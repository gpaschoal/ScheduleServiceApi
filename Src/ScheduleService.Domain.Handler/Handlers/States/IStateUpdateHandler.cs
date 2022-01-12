using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.States;

public interface IStateUpdateHandler : IRequestHandler<StateUpdateCommand, CustomResultData>
{ }
