﻿using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.Countries;

namespace ScheduleService.Application.Validator.Validators.Countries;

public class CountryUpdateValidator : Validation<CountryUpdateCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id).IsRequired();
        ForMember(x => x.Name).IsRequired().HasLenght(50);
        ForMember(x => x.ExternalCode).IsRequired().HasLenght(50);
    }
}
