using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Shared;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.States;

public interface IStateDeleteHandler : IRequestHandler<StateDeleteCommand, CustomResultData>
{ }
