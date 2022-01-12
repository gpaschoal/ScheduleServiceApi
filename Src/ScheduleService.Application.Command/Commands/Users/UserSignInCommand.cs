using ScheduleService.Application.Response.Responses.Users;

namespace ScheduleService.Application.Command.Commands.Users;

public class UserSignInCommand : ICommandExecution<UserSignInResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
