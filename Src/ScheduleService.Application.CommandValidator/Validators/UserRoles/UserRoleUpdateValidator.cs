using FluentValidation;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;

namespace ScheduleService.Application.CommandValidator.Validators.UserRoles;

public class UserRoleUpdateValidator : AbstractValidator<UserRoleUpdateCommand>
{
}
