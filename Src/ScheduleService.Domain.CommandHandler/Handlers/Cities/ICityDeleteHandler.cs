using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Cities;

namespace ScheduleService.Domain.CommandHandler.Handlers.Cities;

public interface ICityDeleteHandler : ICommandHandler<CityDeleteCommand, CustomResultData>
{ }
