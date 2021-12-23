﻿using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Core.Entities;

public class Company : ActivableEntityBase
{
    public Company()
    {
        CompanySubsidiaries = new List<CompanySubsidiary>();
    }

    public Company(string name) : this()
    {
        Name = name;
    }

    public string Name { get; private set; }

    public virtual ICollection<CompanySubsidiary> CompanySubsidiaries { get; private set; }
}
