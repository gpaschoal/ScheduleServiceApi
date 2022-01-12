namespace ScheduleService.Domain.Command.Queries.Cities;

public class GetCityById : IGetById
{
    public Guid Id { get; set; }
}
