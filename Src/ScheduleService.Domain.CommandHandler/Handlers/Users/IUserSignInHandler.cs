using ScheduleService.Application.Response.Responses.Users;
using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Users;

namespace ScheduleService.Domain.CommandHandler.Handlers.Users;

public interface IUserSignInHandler : IRequestHandler<UserSignInCommand, CustomResultData<UserSignInResponse>>
{ }
