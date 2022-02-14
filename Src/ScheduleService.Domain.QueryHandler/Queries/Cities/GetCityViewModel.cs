using ScheduleService.Domain.Command.QueryResponses.Cities;

namespace ScheduleService.Domain.QueryHandler.Queries.Cities;

public class GetCityViewModel : IGetById<CityViewModel>
{
    public Guid Id { get; set; }
}
