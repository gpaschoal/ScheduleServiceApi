using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.States;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.States;

internal class StateCreateRepository : IStateCreateRepository
{
    private readonly IStateRepository _repository;
    private readonly ICountryRepository _countryRepository;

    public StateCreateRepository(
        IStateRepository repository, 
        ICountryRepository countryRepository)
    {
        _repository = repository;
        _countryRepository = countryRepository;
    }

    public ValueTask AddAsync(State data)
    {
        return _repository.AddAsync(data);
    }

    public async ValueTask<bool> CheckIfCountryExists(Guid countryId)
    {
        return await _countryRepository.CheckIfExistByIdAsync(countryId);
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
