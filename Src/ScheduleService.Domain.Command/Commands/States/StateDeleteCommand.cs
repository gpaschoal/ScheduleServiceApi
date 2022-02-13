namespace ScheduleService.Domain.Command.Commands.States;

public class StateDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
