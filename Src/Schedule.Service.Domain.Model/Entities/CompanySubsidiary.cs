using Schedule.Service.Domain.Model.Entities.Base;
using Schedule.Service.Domain.Model.ValueObjects;

namespace Schedule.Service.Domain.Model.Entities;

public class CompanySubsidiary : ActivableEntityBase
{
    public CompanySubsidiary() { }

    public CompanySubsidiary(string name, AddressValueObject address, Guid companyId) : this()
    {
        Name = name;
        Address = address;
        CompanyId = companyId;
    }

    public string Name { get; private set; }
    public AddressValueObject Address { get; private set; }
    public Guid CompanyId { get; private set; }
    public virtual Company Company { get; private set; }
}
