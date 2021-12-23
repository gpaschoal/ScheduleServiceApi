using ScheduleService.Application.Command.Commands.Countries;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.Countries;

public class CountryUpdateHandler : HandlerBase<CountryUpdateCommand, CustomResultData>
{
    public CountryUpdateHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData> HandleExecution(CountryUpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
