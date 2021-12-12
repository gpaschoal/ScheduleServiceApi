using Schedule.Service.Domain.Model.Entities.Base;

namespace Schedule.Service.Domain.Model.Entities;

public class State : ActivableEntityBase
{
    public State()
    {
        Cities = new List<City>();
    }

    public State(string name, string stateCode, Guid countryId) : this()
    {
        Name = name;
        StateCode = stateCode;
        CountryId = countryId;
    }

    public string Name { get; private set; }
    public string StateCode { get; private set; }
    public Guid CountryId { get; private set; }
    public virtual Country Country { get; private set; }

    public virtual ICollection<City> Cities { get; private set; }
}
