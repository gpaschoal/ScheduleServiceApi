using ScheduleService.Application.Command.Commands.Cities;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.Cities;

public class CityDeleteHandler : HandlerBase<CityDeleteCommand, CustomResultData>
{
    public CityDeleteHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData> HandleExecution(CityDeleteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
