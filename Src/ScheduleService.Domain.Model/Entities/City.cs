using ScheduleService.Domain.Model.Entities.Base;

namespace ScheduleService.Domain.Model.Entities;

public class City : ActivableEntityBase
{
    public City() { }

    public City(string name, string externalCode, Guid stateId)
    {
        Name = name;
        ExternalCode = externalCode;
        StateId = stateId;
    }

    public string Name { get; private set; }
    public string ExternalCode { get; private set; }
    public Guid StateId { get; private set; }
    public virtual State State { get; private set; }
}
