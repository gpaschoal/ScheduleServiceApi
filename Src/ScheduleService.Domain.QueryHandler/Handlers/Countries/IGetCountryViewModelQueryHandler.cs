using ScheduleService.Domain.Command.QueryResponses.Countries;
using ScheduleService.Domain.QueryHandler.Queries.Countries;

namespace ScheduleService.Domain.QueryHandler.Handlers.Countries;

public interface IGetCountryViewModelQueryHandler : IQueryHandler<GetCountryViewModel, CountryViewModel?>
{ }
