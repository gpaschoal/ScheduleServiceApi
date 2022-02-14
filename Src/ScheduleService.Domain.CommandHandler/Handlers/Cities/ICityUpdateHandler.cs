using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Cities;

namespace ScheduleService.Domain.CommandHandler.Handlers.Cities;

public interface ICityUpdateHandler : ICommandHandler<CityUpdateCommand, CustomResultData>
{ }
