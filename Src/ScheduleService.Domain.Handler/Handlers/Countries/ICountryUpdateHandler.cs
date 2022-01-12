using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.Countries;

public interface ICountryUpdateHandler : IRequestHandler<CountryUpdateCommand, CustomResultData>
{ }
