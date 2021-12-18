using ScheduleService.Domain.Model.ValueObjects.Base;

namespace ScheduleService.Domain.Model.ValueObjects;

public class CnpjValueObject : DocumentValueObjectBase
{
  public CnpjValueObject(string value) : base(value)
  {
  }
}
