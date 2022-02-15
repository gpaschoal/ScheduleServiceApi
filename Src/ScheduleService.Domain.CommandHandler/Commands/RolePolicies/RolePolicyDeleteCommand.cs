namespace ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

public class RolePolicyDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
