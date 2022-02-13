using ScheduleService.Domain.Command.QueryResponses.Cities;

namespace ScheduleService.Domain.Command.Queries.Cities;

public class GetCityByIdViewModel : IGetById<CityViewModel>
{
    public Guid Id { get; set; }
}
