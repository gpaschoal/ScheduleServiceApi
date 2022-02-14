using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;
using ScheduleService.Domain.CommandHandler.Handlers.RolePolicies;
using ScheduleService.Domain.CommandHandler.Repositories.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Handlers.RolePolicies;

public class RolePolicyUpdateHandler : IRolePolicyUpdateHandler
{
    private readonly IRolePolicyUpdateRepository _repository;

    public RolePolicyUpdateHandler(IRolePolicyUpdateRepository repository)
    {
        _repository = repository;
    }

    public Task<CustomResultData> HandleAsync(RolePolicyUpdateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
