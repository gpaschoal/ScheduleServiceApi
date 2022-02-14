using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;
using ScheduleService.Domain.CommandHandler.Handlers.UserRoles;

namespace ScheduleService.Application.CommandHandler.Handlers.UserRoles;

public class UserRoleDeleteHandler : IUserRoleDeleteHandler
{
    public Task<CustomResultData> HandleAsync(UserRoleDeleteCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
