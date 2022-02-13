using ScheduleService.Domain.Command.QueryResponses.Countries;

namespace ScheduleService.Domain.Command.Queries.Countries;

public class GetCountryByIdViewModel : IGetById<CountryViewModel>
{
    public Guid Id { get; set; }
}
