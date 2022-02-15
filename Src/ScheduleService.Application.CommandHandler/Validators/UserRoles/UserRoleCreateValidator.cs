using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;

namespace ScheduleService.Application.CommandHandler.Validators.UserRoles;

public class UserRoleCreateValidator : AbstractValidator<UserRoleCreateCommand>
{
    public UserRoleCreateValidator()
    {
        RuleFor(x => x.RoleId).NotEmpty().WithMessage(ValidationResource.IsRequired);
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
