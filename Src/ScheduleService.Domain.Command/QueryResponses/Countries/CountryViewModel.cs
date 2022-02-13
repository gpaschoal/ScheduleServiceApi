namespace ScheduleService.Domain.Command.QueryResponses.Countries;

public class CountryViewModel : IViewModelBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ExternalCode { get; set; }
}
