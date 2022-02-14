using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Cities;

namespace ScheduleService.Application.CommandValidator.Validators.Cities;

public class CityDeleteValidator : AbstractValidator<CityDeleteCommand>
{
    public CityDeleteValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
