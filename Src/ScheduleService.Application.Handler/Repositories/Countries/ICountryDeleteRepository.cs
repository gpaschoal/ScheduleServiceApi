﻿using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.Handler.Repositories.Countries;

public interface ICountryDeleteRepository : IDeleteRepository<Country>
{
    ValueTask<bool> CheckIfIsUsedByState(Guid id);
}
