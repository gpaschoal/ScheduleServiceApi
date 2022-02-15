using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Roles;

namespace ScheduleService.Application.CommandHandler.Validators.Roles;

public class RoleCreateValidator : AbstractValidator<RoleCreateCommand>
{
    public RoleCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 150).WithMessage(ValidationResource.ShouldHaveMaxLenght);
    }
}
