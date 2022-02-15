namespace ScheduleService.Domain.CommandHandler.Commands.Roles;

public class RoleDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
