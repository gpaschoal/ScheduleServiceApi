using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;
using ScheduleService.Domain.CommandHandler.Handlers.UserRoles;
using ScheduleService.Domain.CommandHandler.Repositories.UserRoles;

namespace ScheduleService.Application.CommandHandler.Handlers.UserRoles;

public class UserRoleCreateHandler : IUserRoleCreateHandler
{
    private readonly IUserRoleCreateRepository _repository;

    public UserRoleCreateHandler(IUserRoleCreateRepository repository)
    {
        _repository = repository;
    }

    public Task<CustomResultData<Guid>> HandleAsync(UserRoleCreateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
