namespace ScheduleService.Domain.Core.Services.Responses;

public class TokenResponse
{
    public string Token { get; init; }
    public DateTime ExpirationDate { get; init; }
}
