using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.States;

public class StateCreateHandler : HandlerBase<StateCreateCommand, CustomResultData<Guid>>
{
    public StateCreateHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData<Guid>> HandleExecution(StateCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
