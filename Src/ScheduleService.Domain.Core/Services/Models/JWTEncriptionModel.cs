namespace ScheduleService.Domain.Core.Services.Models;

public class JWTEncriptionModel
{
    public string Key { get; set; }
    public int HoursToExpire { get; set; }
}