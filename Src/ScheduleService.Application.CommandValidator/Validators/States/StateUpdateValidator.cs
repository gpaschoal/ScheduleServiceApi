using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.States;

namespace ScheduleService.Application.CommandValidator.Validators.States;

public class StateUpdateValidator : AbstractValidator<StateUpdateCommand>
{
    public StateUpdateValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
        RuleFor(x => x.ExternalCode).Length(5, 50).NotEmpty().WithMessage(ValidationResource.IsRequired).WithMessage(ValidationResource.ShouldHaveMaxLenght);
        RuleFor(x => x.CountryId).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
