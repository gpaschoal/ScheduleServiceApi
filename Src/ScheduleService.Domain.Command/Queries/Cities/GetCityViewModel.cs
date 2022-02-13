using ScheduleService.Domain.Command.QueryResponses.Cities;

namespace ScheduleService.Domain.Command.Queries.Cities;

public class GetCityViewModel : IGetById<CityViewModel>
{
    public Guid Id { get; set; }
}
