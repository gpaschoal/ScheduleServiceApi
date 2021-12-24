﻿using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.Countries;

namespace ScheduleService.Application.Validator.Validators.Countries;

public class CountryDeleteValidator : Validation<CountryDeleteCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id).IsRequired();
    }
}
