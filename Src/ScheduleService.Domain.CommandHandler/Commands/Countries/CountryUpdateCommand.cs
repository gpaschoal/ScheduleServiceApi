﻿namespace ScheduleService.Domain.CommandHandler.Commands.Countries;

public class CountryUpdateCommand : ICommandExecution
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ExternalCode { get; set; }
}
