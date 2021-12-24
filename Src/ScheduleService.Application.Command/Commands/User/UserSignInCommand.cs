using ScheduleService.Application.ViewModelResponses.Responses.User;

namespace ScheduleService.Application.Command.Commands.User;

public class UserSignInCommand : ICommandExecution<UserSignInResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
