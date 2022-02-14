using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.States;

namespace ScheduleService.Application.CommandHandler.Validators.States;

public class StateCreateValidator : AbstractValidator<StateCreateCommand>
{
    public StateCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
        RuleFor(x => x.ExternalCode).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
    }
}
