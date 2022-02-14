using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Roles;
using ScheduleService.Domain.CommandHandler.Handlers.Roles;

namespace ScheduleService.Application.CommandHandler.Handlers.Roles;

public class RoleCreateHandler : IRoleCreateHandler
{
    public Task<CustomResultData<Guid>> HandleAsync(RoleCreateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
