using ScheduleService.Domain.Core.ValueObjects.Base;

namespace ScheduleService.Domain.Core.ValueObjects;

public class CpfValueObject : DocumentValueObjectBase
{
    public CpfValueObject(string value) : base(value)
    {
    }
}
