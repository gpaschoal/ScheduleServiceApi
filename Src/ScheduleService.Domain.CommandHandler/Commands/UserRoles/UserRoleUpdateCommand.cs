namespace ScheduleService.Domain.CommandHandler.Commands.UserRoles;

public class UserRoleUpdateCommand : ICommandExecution
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public bool IsActive { get; set; }
}
