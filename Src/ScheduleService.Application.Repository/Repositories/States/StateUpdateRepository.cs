using ScheduleService.Application.Handler.Repositories.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.States;

public class StateUpdateRepository : IStateUpdateRepository
{
    private readonly IStateRepository _repository;

    public StateUpdateRepository(IStateRepository repository)
    {
        _repository = repository;
    }

    public bool ExistsStateWithExternalCode(Guid id, string externalCode)
    {
        return _repository.ExistsStateWithExternalCode(id, externalCode);
    }

    public bool ExistsStateWithName(Guid id, string name)
    {
        return _repository.ExistsStateWithName(id, name);
    }

    public ValueTask<State?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public ValueTask UpdateAsync(State data)
    {
        return _repository.UpdateAsync(data);
    }
}
