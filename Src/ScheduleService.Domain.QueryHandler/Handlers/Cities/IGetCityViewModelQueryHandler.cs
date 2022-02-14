using ScheduleService.Domain.Command.QueryResponses.Cities;
using ScheduleService.Domain.QueryHandler.Queries.Cities;

namespace ScheduleService.Domain.QueryHandler.Handlers.Cities;

public interface IGetCityViewModelQueryHandler : IQueryHandler<GetCityViewModel, CityViewModel?>
{ }
