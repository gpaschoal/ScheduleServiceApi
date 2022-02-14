using ScheduleService.Domain.CommandHandler.Repositories.UserRoles;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;

namespace ScheduleService.Application.Repository.Repositories.UserRoles;

public class UserRoleUpdateRepository : IUserRoleUpdateRepository
{
    private readonly IUserRoleRepository _repository;

    public UserRoleUpdateRepository(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<UserRole?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public ValueTask UpdateAsync(UserRole data)
    {
        return _repository.UpdateAsync(data);
    }
}
