using Schedule.Service.Domain.Model.Entities.Base;

namespace Schedule.Service.Domain.Model.Entities;

public class City : ActivableEntityBase
{
    public City() { }

    public City(string name, string cityCode, Guid countryId, Guid stateId)
    {
        Name = name;
        CityCode = cityCode;
        CountryId = countryId;
        StateId = stateId;
    }

    public string Name { get; private set; }
    public string CityCode { get; private set; }
    public Guid StateId { get; private set; }
    public virtual State State { get; private set; }
    public Guid CountryId { get; private set; }
    public virtual Country Country { get; private set; }
}
