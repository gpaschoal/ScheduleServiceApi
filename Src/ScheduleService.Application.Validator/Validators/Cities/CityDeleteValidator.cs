﻿using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.Cities;

namespace ScheduleService.Application.Validator.Validators.Cities;

public class CityDeleteValidator : Validation<CityDeleteCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id).IsRequired();
    }
}
