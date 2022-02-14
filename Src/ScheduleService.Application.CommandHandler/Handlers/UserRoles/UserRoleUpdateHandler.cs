using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;
using ScheduleService.Domain.CommandHandler.Handlers.UserRoles;
using ScheduleService.Domain.CommandHandler.Repositories.UserRoles;

namespace ScheduleService.Application.CommandHandler.Handlers.UserRoles;

public class UserRoleUpdateHandler : IUserRoleUpdateHandler
{
    private readonly IUserRoleUpdateRepository _repository;

    public UserRoleUpdateHandler(IUserRoleUpdateRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<CustomResultData> HandleAsync(UserRoleUpdateCommand request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
