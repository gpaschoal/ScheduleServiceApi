using FluentValidation;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;

namespace ScheduleService.Application.CommandValidator.Validators.UserRoles;

public class UserRoleDeleteValidator : AbstractValidator<UserRoleDeleteCommand>
{
}
