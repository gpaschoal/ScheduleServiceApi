using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Validators.RolePolicies;

public class RolePolicyUpdateValidator : AbstractValidator<RolePolicyUpdateCommand>
{
    public RolePolicyUpdateValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
        RuleFor(x => x.Policy).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 150).WithMessage(ValidationResource.ShouldHaveMaxLenght);
        RuleFor(x => x.RoleId).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
