using Schedule.Service.Domain.Model.Entities.Base;
using Schedule.Service.Domain.Model.Keys;

namespace Schedule.Service.Domain.Model.Entities;

public class Country : ActivableEntityBase<CountryKey>
{
    public Country()
    {
        States = new List<State>();
    }

    public Country(string name, string countryCode) : this()
    {
        Id = new(Guid.NewGuid());
        Name = name;
        CountryCode = countryCode;
    }

    public string Name { get; private set; }
    public string CountryCode { get; private set; }

    public virtual ICollection<State> States { get; private set; }
}
