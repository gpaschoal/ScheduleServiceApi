using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;
using ScheduleService.Domain.CommandHandler.Handlers.UserRoles;

namespace ScheduleService.Application.CommandHandler.Handlers.UserRoles;

public class UserRoleCreateHandler : IUserRoleCreateHandler
{
    public Task<CustomResultData<Guid>> HandleAsync(UserRoleCreateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
