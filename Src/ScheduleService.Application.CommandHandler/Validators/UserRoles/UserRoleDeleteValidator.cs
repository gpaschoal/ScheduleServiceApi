using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;

namespace ScheduleService.Application.CommandHandler.Validators.UserRoles;

public class UserRoleDeleteValidator : AbstractValidator<UserRoleDeleteCommand>
{
    public UserRoleDeleteValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
