using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Countries;

namespace ScheduleService.Application.CommandValidator.Validators.Countries;

public class CountryCreateValidator : AbstractValidator<CountryCreateCommand>
{
    public CountryCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
        RuleFor(x => x.ExternalCode).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
    }
}
