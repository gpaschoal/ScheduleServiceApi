using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Cities;

namespace ScheduleService.Application.CommandValidator.Validators.Cities;

public class CityUpdateValidator : AbstractValidator<CityUpdateCommand>
{
    public CityUpdateValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
        RuleFor(x => x.StateId).NotEmpty().WithMessage(ValidationResource.IsRequired);
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
        RuleFor(x => x.ExternalCode).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
    }
}
