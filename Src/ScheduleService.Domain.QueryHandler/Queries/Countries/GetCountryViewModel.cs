﻿using ScheduleService.Domain.Command.QueryResponses.Countries;

namespace ScheduleService.Domain.QueryHandler.Queries.Countries;

public class GetCountryViewModel : IGetById<CountryViewModel>
{
    public Guid Id { get; set; }
}
