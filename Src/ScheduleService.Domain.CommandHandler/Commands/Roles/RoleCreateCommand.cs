namespace ScheduleService.Domain.CommandHandler.Commands.Roles;

public class RoleCreateCommand : ICommandExecution<Guid>
{
    public string? Name { get; set; }
}
