using ScheduleService.Application.Command.Commands.Countries;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.Countries;

public class CountryDeleteHandler : HandlerBase<CountryDeleteCommand, CustomResultData>
{
    public CountryDeleteHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData> HandleExecution(CountryDeleteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
