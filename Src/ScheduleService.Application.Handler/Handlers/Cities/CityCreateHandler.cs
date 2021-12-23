using ScheduleService.Application.Command.Commands.Cities;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.Cities;

public class CityCreateHandler : HandlerBase<CityCreateCommand, CustomResultData<Guid>>
{
    public CityCreateHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData<Guid>> HandleExecution(CityCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
