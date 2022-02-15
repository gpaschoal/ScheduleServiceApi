namespace ScheduleService.Domain.CommandHandler.Commands.UserRoles;

public class UserRoleDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
