using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Roles;
using ScheduleService.Domain.CommandHandler.Handlers.Roles;

namespace ScheduleService.Application.CommandHandler.Handlers.Roles;

public class RoleUpdateHandler : IRoleUpdateHandler
{
    public Task<CustomResultData> HandleAsync(RoleUpdateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
