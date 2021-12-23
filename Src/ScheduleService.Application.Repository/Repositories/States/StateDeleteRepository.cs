using ScheduleService.Application.Handler.Repositories.States;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.States;

public class StateDeleteRepository : IStateDeleteRepository
{
    private readonly IStateRepository _repository;

    public StateDeleteRepository(IStateRepository repository)
    {
        _repository = repository;
    }

    public ValueTask DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }
}
