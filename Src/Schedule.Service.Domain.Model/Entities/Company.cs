using Schedule.Service.Domain.Model.Entities.Base;

namespace Schedule.Service.Domain.Model.Entities;

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
