using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.States;

public class StateUpdateHandler : HandlerBase<StateUpdateCommand, CustomResultData>
{
    public StateUpdateHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData> HandleExecution(StateUpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
