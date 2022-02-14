using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;
using ScheduleService.Domain.CommandHandler.Handlers.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Handlers.RolePolicies;

public class RolePolicyCreateHandler : IRolePolicyCreateHandler
{
    public Task<CustomResultData<Guid>> HandleAsync(RolePolicyCreateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
