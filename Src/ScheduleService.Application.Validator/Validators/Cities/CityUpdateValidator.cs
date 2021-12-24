using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.Cities;

namespace ScheduleService.Application.Validator.Validators.Cities;

public class CityUpdateValidator : Validation<CityUpdateCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id).IsRequired();
        ForMember(x => x.Name).IsRequired().HasLenght(50);
        ForMember(x => x.ExternalCode).IsRequired().HasLenght(50);
    }
}
