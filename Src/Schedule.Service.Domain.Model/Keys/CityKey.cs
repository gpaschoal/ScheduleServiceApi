using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Keys;

public record struct CityKey(Guid CountryId, Guid StateId, Guid Id) : IKey;