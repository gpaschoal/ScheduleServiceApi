﻿using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Cities;

public class CityDeleteRepository : ICityDeleteRepository
{
    private readonly ICityRepository _repository;

    public CityDeleteRepository(ICityRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<bool> CheckIfExistByIdAsync(Guid id)
    {
        return _repository.CheckIfExistByIdAsync(id);
    }

    public ValueTask DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }

    public ValueTask<City?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }
}
