namespace ScheduleService.Domain.CommandHandler.Commands.States;

public class StateDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
