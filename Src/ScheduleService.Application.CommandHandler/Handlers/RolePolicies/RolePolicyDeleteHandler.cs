using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;
using ScheduleService.Domain.CommandHandler.Handlers.RolePolicies;
using ScheduleService.Domain.CommandHandler.Repositories.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Handlers.RolePolicies;

public class RolePolicyDeleteHandler : IRolePolicyDeleteHandler
{
    private readonly IRolePolicyDeleteRepository _repository;

    public RolePolicyDeleteHandler(IRolePolicyDeleteRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<CustomResultData> HandleAsync(RolePolicyDeleteCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
