﻿using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.States;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.States;

internal class StateCreateRepository : IStateCreateRepository
{
    private readonly IStateRepository _repository;

    public StateCreateRepository(IStateRepository repository)
    {
        _repository = repository;
    }

    public ValueTask AddAsync(State data)
    {
        return _repository.AddAsync(data);
    }

    public bool ExistsStateWithExternalCode(string externalCode)
    {
        return _repository.ExistsStateWithExternalCode(externalCode);
    }

    public bool ExistsStateWithName(string name)
    {
        return _repository.ExistsStateWithName(name);
    }
}
