namespace ScheduleService.Domain.CommandHandler.Commands.Roles;

public class RoleUpdateCommand : ICommandExecution
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }
}
