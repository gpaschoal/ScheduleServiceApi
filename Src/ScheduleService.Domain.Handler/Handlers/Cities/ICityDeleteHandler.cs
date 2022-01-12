using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Cities;

namespace ScheduleService.Domain.Handler.Handlers.Cities;

public interface ICityDeleteHandler : IRequestHandler<CityDeleteCommand, CustomResultData>
{ }
