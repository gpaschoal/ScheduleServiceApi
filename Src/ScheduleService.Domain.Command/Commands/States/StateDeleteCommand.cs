using ScheduleService.Domain.Command.Commands;

namespace ScheduleService.Application.Command.Commands.States;

public class StateDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
