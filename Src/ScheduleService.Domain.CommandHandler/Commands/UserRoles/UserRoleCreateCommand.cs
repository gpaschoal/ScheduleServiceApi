namespace ScheduleService.Domain.CommandHandler.Commands.UserRoles;

public class UserRoleCreateCommand : ICommandExecution<Guid>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}
}
