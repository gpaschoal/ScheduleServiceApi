using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;
using ScheduleService.Domain.CommandHandler.Handlers.UserRoles;
using ScheduleService.Domain.CommandHandler.Repositories.UserRoles;

namespace ScheduleService.Application.CommandHandler.Handlers.UserRoles;

public class UserRoleDeleteHandler : IUserRoleDeleteHandler
{
    private readonly IUserRoleDeleteRepository _repository;

    public UserRoleDeleteHandler(IUserRoleDeleteRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<CustomResultData> HandleAsync(UserRoleDeleteCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
