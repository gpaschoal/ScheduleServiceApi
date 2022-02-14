using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.Roles;

namespace ScheduleService.Domain.CommandHandler.Handlers.Roles;

public interface IRoleDeleteHandler : ICommandHandler<RoleDeleteCommand, CustomResultData>
{ }
