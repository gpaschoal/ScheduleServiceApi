using ScheduleService.Domain.Core.ValueObjects.Base;

namespace ScheduleService.Domain.Core.ValueObjects;

public class CnpjValueObject : DocumentValueObjectBase
{
    public CnpjValueObject(string value) : base(value)
    {
    }
}
