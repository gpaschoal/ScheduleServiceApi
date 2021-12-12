using Schedule.Service.Domain.Model.Entities.Base;
using Schedule.Service.Domain.Model.Keys;

namespace Schedule.Service.Domain.Model.Entities;

public class City : ActivableEntityBase<CityKey>
{
    public City() { }

    public City(string name, string cityCode, Guid countryId, Guid stateId)
    {
        Name = name;
        CityCode = cityCode;
        StateId = new(countryId, stateId);
    }

    public string Name { get; private set; }
    public string CityCode { get; private set; }
    public StateKey StateId { get; private set; }
    public virtual State State { get; private set; }
}
