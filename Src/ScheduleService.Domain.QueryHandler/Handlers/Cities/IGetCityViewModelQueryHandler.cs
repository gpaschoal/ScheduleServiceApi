using ScheduleService.Domain.Command.Queries.Cities;
using ScheduleService.Domain.Command.QueryResponses.Cities;

namespace ScheduleService.Domain.QueryHandler.Handlers.Cities;

public interface IGetCityViewModelQueryHandler : IQueryHandler<GetCityViewModel, CityViewModel?>
{ }
