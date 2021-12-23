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

    public ValueTask UpdateAsync(State data)
    {
        return _repository.UpdateAsync(data);
    }
}
