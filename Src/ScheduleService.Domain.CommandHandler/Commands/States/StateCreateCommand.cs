namespace ScheduleService.Domain.CommandHandler.Commands.States;

public class StateCreateCommand : ICommandExecution<Guid>
{
    public string? Name { get; set; }
    public string? ExternalCode { get; set; }
    public Guid CountryId { get; set; }
}
