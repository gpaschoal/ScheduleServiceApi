using ScheduleService.Domain.Command.Queries.Countries;
using ScheduleService.Domain.Command.QueryResponses.Countries;

namespace ScheduleService.Domain.QueryHandler.Handlers.Countries;

public interface IGetCountryViewModelQuery : IQueryHandler<GetCountryViewModel, CountryViewModel>
{ }
