using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.CommandResponses.Users;
using ScheduleService.Domain.CommandHandler.Commands.Users;

namespace ScheduleService.Domain.CommandHandler.Handlers.Users;

public interface IUserSignInHandler : ICommandHandler<UserSignInCommand, CustomResultData<UserSignInResponse>>
{ }
