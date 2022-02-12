using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Countries;

namespace ScheduleService.Domain.CommandHandler.Handlers.Countries;

public interface ICountryDeleteHandler : IRequestHandler<CountryDeleteCommand, CustomResultData>
{ }
