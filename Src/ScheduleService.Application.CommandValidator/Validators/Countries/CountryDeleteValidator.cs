using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Countries;

namespace ScheduleService.Application.CommandValidator.Validators.Countries;

public class CountryDeleteValidator : AbstractValidator<CountryDeleteCommand>
{
    public CountryDeleteValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
