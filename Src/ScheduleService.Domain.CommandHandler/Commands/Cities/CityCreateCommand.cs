namespace ScheduleService.Domain.CommandHandler.Commands.Cities;

public class CityCreateCommand : ICommandExecution<Guid>
{
    public string? Name { get; set; }
    public string? ExternalCode { get; set; }
    public Guid StateId { get; set; }
}
