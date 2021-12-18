using Schedule.Service.Domain.Model.ValueObjects.Base;

namespace Schedule.Service.Domain.Model.ValueObjects;

public class CnpjValueObject : DocumentValueObjectBase
{
    public CnpjValueObject(string value) : base(value)
    {
    }
}
