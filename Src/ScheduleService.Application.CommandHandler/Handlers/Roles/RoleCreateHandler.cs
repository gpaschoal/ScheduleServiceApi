using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Roles;
using ScheduleService.Domain.CommandHandler.Handlers.Roles;
using ScheduleService.Domain.CommandHandler.Repositories.Roles;

namespace ScheduleService.Application.CommandHandler.Handlers.Roles;

public class RoleCreateHandler : IRoleCreateHandler
{
    private readonly IRoleCreateRepository _repository;

    public RoleCreateHandler(IRoleCreateRepository repository)
    {
        _repository = repository;
    }

    public Task<CustomResultData<Guid>> HandleAsync(RoleCreateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
