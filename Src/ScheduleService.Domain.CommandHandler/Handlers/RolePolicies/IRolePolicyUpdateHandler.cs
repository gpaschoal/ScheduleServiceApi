using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

namespace ScheduleService.Domain.CommandHandler.Handlers.RolePolicies;

public interface IRolePolicyUpdateHandler : ICommandHandler<RolePolicyUpdateCommand, CustomResultData>
{ }
