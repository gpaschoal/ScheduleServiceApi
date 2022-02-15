using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Roles;

namespace ScheduleService.Application.CommandHandler.Validators.Roles;

public class RoleDeleteValidator : AbstractValidator<RoleDeleteCommand>
{
    public RoleDeleteValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
