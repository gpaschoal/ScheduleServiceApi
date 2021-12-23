using ScheduleService.Application.Handler.Services.Responses;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.Handler.Services;

public interface ITokenService
{
    TokenResponse TokenGenerator(User user);
}
