using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Validators.RolePolicies;

public class RolePolicyCreateValidator : AbstractValidator<RolePolicyCreateCommand>
{
    public RolePolicyCreateValidator()
    {
        RuleFor(x => x.Policy).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 150).WithMessage(ValidationResource.ShouldHaveMaxLenght);
        RuleFor(x => x.RoleId).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
