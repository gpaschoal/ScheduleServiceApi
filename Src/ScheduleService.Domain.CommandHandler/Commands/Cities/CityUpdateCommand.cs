namespace ScheduleService.Domain.CommandHandler.Commands.Cities;

public class CityUpdateCommand : ICommandExecution
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ExternalCode { get; set; }
    public Guid StateId { get; set; }
}
