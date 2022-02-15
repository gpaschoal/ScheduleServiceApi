namespace ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

public class RolePolicyCreateCommand : ICommandExecution<Guid>
{

    public string? Policy { get; set; }
    public Guid RoleId { get; set; }
}
