using ScheduleService.Application.Response.Responses.Users;
using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Users;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.Users;

public interface IUserSignInHandler : IRequestHandler<UserSignInCommand, CustomResultData<UserSignInResponse>>
{ }
