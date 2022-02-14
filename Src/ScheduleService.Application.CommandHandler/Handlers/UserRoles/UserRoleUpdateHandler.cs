using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;
using ScheduleService.Domain.CommandHandler.Handlers.UserRoles;

namespace ScheduleService.Application.CommandHandler.Handlers.UserRoles;

public class UserRoleUpdateHandler : IUserRoleUpdateHandler
{
    public Task<CustomResultData> HandleAsync(UserRoleUpdateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
