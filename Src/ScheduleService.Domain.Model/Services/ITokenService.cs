using ScheduleService.Domain.Model.Entities;
using ScheduleService.Domain.Model.Services.Responses;

namespace ScheduleService.Domain.Model.Services;

public interface ITokenService
{
    TokenResponse TokenGenerator(User user);
}
