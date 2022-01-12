using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.States;

namespace ScheduleService.Domain.Handler.Handlers.States;

public interface IStateCreateHandler : IRequestHandler<StateCreateCommand, CustomResultData<Guid>>
{ }
