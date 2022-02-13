namespace ScheduleService.Domain.Command.Commands.Countries;

public class CountryDeleteCommand : ICommandExecution
{
    public Guid Id { get; set; }
}
