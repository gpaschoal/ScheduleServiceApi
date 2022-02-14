using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;
using ScheduleService.Domain.CommandHandler.Handlers.RolePolicies;
using ScheduleService.Domain.CommandHandler.Repositories.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Handlers.RolePolicies;

public class RolePolicyCreateHandler : IRolePolicyCreateHandler
{
    private readonly IRolePolicyCreateRepository _repository;

    public RolePolicyCreateHandler(IRolePolicyCreateRepository repository)
    {
        _repository = repository;
    }

    public Task<CustomResultData<Guid>> HandleAsync(RolePolicyCreateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
