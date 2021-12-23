using ScheduleService.Application.Command.Commands.Countries;
using ScheduleService.Application.Shared;

namespace ScheduleService.Application.Handler.Handlers.Countries;

public class CountryCreateHandler : HandlerBase<CountryCreateCommand, CustomResultData<Guid>>
{
    public CountryCreateHandler(IHandlerBus handlerBus) : base(handlerBus)
    { }

    public override Task<CustomResultData<Guid>> HandleExecution(CountryCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

