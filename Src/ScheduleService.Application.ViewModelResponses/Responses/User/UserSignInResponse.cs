namespace ScheduleService.Application.ViewModelResponses.Responses.User;

public class UserSignInResponse
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpireAt { get; set; }
}
