namespace ScheduleService.Domain.Command.Commands.Cities;

public class CityDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
