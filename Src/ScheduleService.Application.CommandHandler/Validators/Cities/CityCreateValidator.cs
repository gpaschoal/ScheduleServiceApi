using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Cities;

namespace ScheduleService.Application.CommandHandler.Validators.Cities;

public class CityCreateValidator : AbstractValidator<CityCreateCommand>
{
    public CityCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);

        RuleFor(x => x.ExternalCode).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
    }
}
