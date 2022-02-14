using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;
using ScheduleService.Domain.CommandHandler.Handlers.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Handlers.RolePolicies;

public class RolePolicyDeleteHandler : IRolePolicyDeleteHandler
{
    public Task<CustomResultData> HandleAsync(RolePolicyDeleteCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
