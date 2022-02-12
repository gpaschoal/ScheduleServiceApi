using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.States;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.States;

internal class StateUpdateRepository : IStateUpdateRepository
{
    private readonly IStateRepository _repository;
    private readonly ICountryRepository _countryRepository;

    public StateUpdateRepository(
        IStateRepository repository, 
        ICountryRepository countryRepository)
    {
        _repository = repository;
        _countryRepository = countryRepository;
    }

    public async ValueTask<bool> CheckIfCountryExists(Guid countryId)
    {
        return await _countryRepository.CheckIfExistByIdAsync(countryId);
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
