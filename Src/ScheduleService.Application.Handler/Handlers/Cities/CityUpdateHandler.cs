using ScheduleService.Application.Command.Commands.Cities;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.Cities;

public class CityUpdateHandler : HandlerBase<CityCreateCommand, CustomResultData<Guid>>
{
    public CityUpdateHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData<Guid>> HandleExecution(CityCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
