using ScheduleService.Application.Command.Commands.User;
using ScheduleService.Application.Shared;
using ScheduleService.Application.ViewModelResponses.Responses.User;

namespace ScheduleService.Application.Handler.Handlers.Users;

public class UserSignInHandler : HandlerBase<UserSignInCommand, CustomResultData<UserSignInResponse>>
{
    public UserSignInHandler(IHandlerBus handlerBus) : base(handlerBus)
    {
    }

    public override Task<CustomResultData<UserSignInResponse>> HandleExecution(UserSignInCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
