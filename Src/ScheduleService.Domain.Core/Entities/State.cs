using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Core.Entities;

public class State : ActivableEntityBase
{
    public State()
    {
        Cities = new List<City>();
    }

    public State(string name, string externalCode, Guid countryId) : this()
    {
        Name = name;
        ExternalCode = externalCode;
        CountryId = countryId;
    }

    public string Name { get; private set; }
    public string ExternalCode { get; private set; }
    public Guid CountryId { get; private set; }
    public virtual Country Country { get; private set; }

    public virtual ICollection<City> Cities { get; private set; }

    public void Update(string name, string externalCode)
    {
        Name = name;
        ExternalCode = externalCode;
    }
}
