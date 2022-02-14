using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.States;

namespace ScheduleService.Domain.CommandHandler.Handlers.States;

public interface IStateDeleteHandler : ICommandHandler<StateDeleteCommand, CustomResultData>
{ }
