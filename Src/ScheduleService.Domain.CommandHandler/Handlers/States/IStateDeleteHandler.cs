using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.States;

namespace ScheduleService.Domain.CommandHandler.Handlers.States;

public interface IStateDeleteHandler : IRequestHandler<StateDeleteCommand, CustomResultData>
{ }
