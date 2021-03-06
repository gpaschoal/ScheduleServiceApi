using ScheduleService.Domain.Core.Entities.Base;
using ScheduleService.Domain.Core.ValueObjects;

namespace ScheduleService.Domain.Core.Entities;

public class CompanySubsidiary : ActivableEntityBase
{
    public CompanySubsidiary() { }

    public CompanySubsidiary(string name, AddressValueObject address, Guid companyId, CnpjValueObject cnpj) : this()
    {
        Name = name;
        Address = address;
        CompanyId = companyId;
        Cnpj = cnpj;
    }

    public string Name { get; private set; }
    public CnpjValueObject Cnpj { get; private set; }
    public AddressValueObject Address { get; private set; }
    public Guid CompanyId { get; private set; }
    public virtual Company Company { get; private set; }
}
