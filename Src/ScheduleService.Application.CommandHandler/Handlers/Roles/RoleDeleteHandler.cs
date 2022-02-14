using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Roles;
using ScheduleService.Domain.CommandHandler.Handlers.Roles;

namespace ScheduleService.Application.CommandHandler.Handlers.Roles;

public class RoleDeleteHandler : IRoleDeleteHandler
{
    public Task<CustomResultData> HandleAsync(RoleDeleteCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
