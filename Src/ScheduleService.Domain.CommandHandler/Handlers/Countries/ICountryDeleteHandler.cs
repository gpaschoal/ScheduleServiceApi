using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Countries;

namespace ScheduleService.Domain.CommandHandler.Handlers.Countries;

public interface ICountryDeleteHandler : ICommandHandler<CountryDeleteCommand, CustomResultData>
{ }
