using ScheduleService.Domain.CommandHandler.Repositories.RolePolicies;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.RolePolicies;

public class RolePolicyCreateRepository : IRolePolicyCreateRepository
{
    private readonly IRolePolicyRepository _repository;

    public RolePolicyCreateRepository(IRolePolicyRepository repository)
    {
        _repository = repository;
    }

    public ValueTask AddAsync(RolePolicy data)
    {
        return _repository.AddAsync(data);
    }
}
