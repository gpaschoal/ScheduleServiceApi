namespace ScheduleService.Domain.CommandHandler.Commands.Cities;

public class CityDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
