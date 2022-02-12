using ScheduleService.Application.CommandHandler.Services.Responses;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.CommandHandler.Services;

public interface ITokenService
{
    TokenResponse TokenGenerator(User user);
}
