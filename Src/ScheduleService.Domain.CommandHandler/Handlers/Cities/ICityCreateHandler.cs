using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Cities;

namespace ScheduleService.Domain.CommandHandler.Handlers.Cities;

public interface ICityCreateHandler : ICommandHandler<CityCreateCommand, CustomResultData<Guid>>
{ }
