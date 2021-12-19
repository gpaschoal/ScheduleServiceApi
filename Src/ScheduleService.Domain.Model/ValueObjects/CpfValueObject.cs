using ScheduleService.Domain.Model.ValueObjects.Base;

namespace ScheduleService.Domain.Model.ValueObjects;

public class CpfValueObject : DocumentValueObjectBase
{
    public CpfValueObject(string value) : base(value)
    {
    }
}
