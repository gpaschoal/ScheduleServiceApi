﻿using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Countries;

public interface ICountryDeleteRepository : IDeleteRepository<Country>
{
    ValueTask<bool> CheckIfIsUsedByStateAsync(Guid id);
}
