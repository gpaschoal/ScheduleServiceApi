namespace ScheduleService.Application.Command.Queries.Cities;

public class GetCityById : IGetById
{
    public Guid Id { get; set; }
}
