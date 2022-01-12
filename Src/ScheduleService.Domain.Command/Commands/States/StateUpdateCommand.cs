namespace ScheduleService.Domain.Command.Commands.States;

public class StateUpdateCommand : ICommandExecution
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ExternalCode { get; set; }
    public Guid CountryId { get; set; }
}
