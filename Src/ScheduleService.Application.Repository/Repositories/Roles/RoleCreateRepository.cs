using ScheduleService.Domain.CommandHandler.Repositories.Roles;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Roles;

public class RoleCreateRepository : IRoleCreateRepository
{
    private readonly IRoleRepository _repository;

    public RoleCreateRepository(IRoleRepository repository)
    {
        _repository = repository;
    }

    public ValueTask AddAsync(Role data)
    {
        return _repository.AddAsync(data);
    }
}
