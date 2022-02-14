using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Roles;
using ScheduleService.Domain.CommandHandler.Handlers.Roles;
using ScheduleService.Domain.CommandHandler.Repositories.Roles;

namespace ScheduleService.Application.CommandHandler.Handlers.Roles;

public class RoleDeleteHandler : IRoleDeleteHandler
{
    private readonly IRoleDeleteRepository _repository;

    public RoleDeleteHandler(IRoleDeleteRepository repository)
    {
        _repository = repository;
    }

    public Task<CustomResultData> HandleAsync(RoleDeleteCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
