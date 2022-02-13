using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.CommandResponses.Users;
using ScheduleService.Domain.Command.Commands.Users;

namespace ScheduleService.Domain.CommandHandler.Handlers.Users;

public interface IUserSignInHandler : IRequestHandler<UserSignInCommand, CustomResultData<UserSignInResponse>>
{ }
