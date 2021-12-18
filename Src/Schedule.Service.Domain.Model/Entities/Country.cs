using Schedule.Service.Domain.Model.Entities.Base;

namespace Schedule.Service.Domain.Model.Entities;

public class Country : ActivableEntityBase
{
    public Country()
    {
        Name = "";
        CountryCode = "";
        States = new List<State>();
        Cities = new List<City>();
    }

    public Country(string name, string countryCode) : this()
    {
        Name = name;
        CountryCode = countryCode;
    }

    public string Name { get; private set; }
    public string CountryCode { get; private set; }

    public virtual ICollection<State> States { get; private set; }
    public virtual ICollection<City> Cities { get; private set; }
}
