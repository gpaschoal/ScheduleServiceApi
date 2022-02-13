namespace ScheduleService.Application.Command.Commands.Countries;

public class CountryCreateCommand : ICommandExecution<Guid>
{
    public string Name { get; set; }
    public string ExternalCode { get; set; }
}
