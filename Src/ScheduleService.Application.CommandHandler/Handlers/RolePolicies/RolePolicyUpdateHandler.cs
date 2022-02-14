using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;
using ScheduleService.Domain.CommandHandler.Handlers.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Handlers.RolePolicies;

public class RolePolicyUpdateHandler : IRolePolicyUpdateHandler
{
    public Task<CustomResultData> HandleAsync(RolePolicyUpdateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
