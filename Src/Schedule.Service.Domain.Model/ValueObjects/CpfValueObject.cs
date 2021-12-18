using Schedule.Service.Domain.Model.ValueObjects.Base;

namespace Schedule.Service.Domain.Model.ValueObjects;

public class CpfValueObject : DocumentValueObjectBase
{
    public CpfValueObject(string value) : base(value)
    {
    }
}
