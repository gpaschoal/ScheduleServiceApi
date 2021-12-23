using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.States;

public class StateDeleteHandler : HandlerBase<StateDeleteCommand, CustomResultData>
{
    public StateDeleteHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData> HandleExecution(StateDeleteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
