using ScheduleService.Domain.CommandHandler.Repositories.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;

namespace ScheduleService.Application.Repository.Repositories.States;

internal class StateDeleteRepository : IStateDeleteRepository
{
    private readonly IStateRepository _repository;

    public StateDeleteRepository(IStateRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<bool> CheckIfExistByIdAsync(Guid id)
    {
        return _repository.CheckIfExistByIdAsync(id);
    }

    public ValueTask<bool> CheckIfIsUsedByCityAsync(Guid id)
    {
        return _repository.CheckIfIsUsedByCityAsync(id);
    }

    public ValueTask DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }

    public ValueTask<State?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }
}
