namespace ScheduleService.Domain.CommandHandler.Commands.Countries;

public class CountryDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
