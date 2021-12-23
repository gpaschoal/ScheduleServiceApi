using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Services.Responses;

namespace ScheduleService.Domain.Core.Services;

public interface ITokenService
{
    TokenResponse TokenGenerator(User user);
}
