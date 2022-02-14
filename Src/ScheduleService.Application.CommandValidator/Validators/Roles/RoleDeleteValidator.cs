using FluentValidation;
using ScheduleService.Domain.CommandHandler.Commands.Roles;

namespace ScheduleService.Application.CommandValidator.Validators.Roles;

public class RoleDeleteValidator : AbstractValidator<RoleDeleteCommand>
{
}
