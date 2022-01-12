namespace ScheduleService.Domain.Command.Queries.Countries;

public class GetCountryById : IGetById
{
    public Guid Id { get; set; }
}
