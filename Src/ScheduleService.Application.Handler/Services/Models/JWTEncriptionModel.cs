namespace ScheduleService.Application.Handler.Services.Models;

public class JWTEncriptionModel
{
    public string Key { get; set; }
    public int HoursToExpire { get; set; }
}