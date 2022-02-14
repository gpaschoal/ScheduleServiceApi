using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;

namespace ScheduleService.Domain.CommandHandler.Handlers.UserRoles;

public interface IUserRoleUpdateHandler : ICommandHandler<UserRoleUpdateCommand, CustomResultData>
{ }
