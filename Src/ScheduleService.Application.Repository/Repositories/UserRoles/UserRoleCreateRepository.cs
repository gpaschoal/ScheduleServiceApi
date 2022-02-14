using ScheduleService.Domain.CommandHandler.Repositories.UserRoles;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.UserRoles;

public class UserRoleCreateRepository : IUserRoleCreateRepository
{
    private readonly IUserRoleRepository _repository;

    public UserRoleCreateRepository(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public ValueTask AddAsync(UserRole data)
    {
        return _repository.AddAsync(data);
    }
}
