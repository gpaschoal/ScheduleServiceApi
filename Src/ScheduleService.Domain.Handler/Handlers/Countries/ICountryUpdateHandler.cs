using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Countries;

namespace ScheduleService.Domain.Handler.Handlers.Countries;

public interface ICountryUpdateHandler : IRequestHandler<CountryUpdateCommand, CustomResultData>
{ }
