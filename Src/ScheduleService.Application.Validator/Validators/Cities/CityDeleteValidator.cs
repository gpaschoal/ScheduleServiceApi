using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Cities;

namespace ScheduleService.Application.Validator.Validators.Cities;

public class CityDeleteValidator : AbstractValidator<CityDeleteCommand>
{
    public CityDeleteValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
