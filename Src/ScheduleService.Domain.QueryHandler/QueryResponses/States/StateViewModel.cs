namespace ScheduleService.Domain.Command.QueryResponses.States;

public class StateViewModel : IViewModelBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ExternalCode { get; set; }
    public Guid CountryId { get; set; }
    public string CountryName { get; set; }
    public string CountryExternalCode { get; set; }
}
