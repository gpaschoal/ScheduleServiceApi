using FluentValidation;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;

namespace ScheduleService.Application.CommandHandler.Validators.UserRoles;

public class UserRoleDeleteValidator : AbstractValidator<UserRoleDeleteCommand>
{
}
