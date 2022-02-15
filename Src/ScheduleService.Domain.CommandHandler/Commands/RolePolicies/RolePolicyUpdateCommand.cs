namespace ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

public class RolePolicyUpdateCommand : ICommandExecution
{
    public Guid Id { get; set; }
    public string? Policy { get; set; }
    public Guid RoleId { get; set; }
}
