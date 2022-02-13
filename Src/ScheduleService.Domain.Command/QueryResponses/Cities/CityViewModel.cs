using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Command.QueryResponses.Cities;

public class CityViewModel : IViewModelBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ExternalCode { get; set; }
    public Guid StateId { get; set; }
    public string StateName { get; set; }
    public string StateExternalCode { get; set; }
    public Guid CountryId { get; set; }
    public string CountryName { get; set; }
    public string CountryExternalCode { get; set; }
}
