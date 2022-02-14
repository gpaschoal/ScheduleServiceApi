using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Roles;
using ScheduleService.Domain.CommandHandler.Handlers.Roles;
using ScheduleService.Domain.CommandHandler.Repositories.Roles;

namespace ScheduleService.Application.CommandHandler.Handlers.Roles;

public class RoleUpdateHandler : IRoleUpdateHandler
{
    private readonly IRoleUpdateRepository _repository;

    public RoleUpdateHandler(IRoleUpdateRepository repository)
    {
        _repository = repository;
    }

    public Task<CustomResultData> HandleAsync(RoleUpdateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
