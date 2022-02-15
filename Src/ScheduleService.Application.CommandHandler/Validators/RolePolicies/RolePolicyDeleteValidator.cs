using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Validators.RolePolicies;

public class RolePolicyDeleteValidator : AbstractValidator<RolePolicyDeleteCommand>
{
    public RolePolicyDeleteValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
