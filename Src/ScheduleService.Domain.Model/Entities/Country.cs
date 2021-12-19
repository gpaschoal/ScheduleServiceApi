﻿using ScheduleService.Domain.Model.Entities.Base;

namespace ScheduleService.Domain.Model.Entities;

public class Country : ActivableEntityBase
{
    public Country()
    {
        Name = "";
        ExternalCode = "";
        States = new List<State>();
    }

    public Country(string name, string externalCode) : this()
    {
        Name = name;
        ExternalCode = externalCode;
    }

    public string Name { get; private set; }
    public string ExternalCode { get; private set; }

    public virtual ICollection<State> States { get; private set; }
}
