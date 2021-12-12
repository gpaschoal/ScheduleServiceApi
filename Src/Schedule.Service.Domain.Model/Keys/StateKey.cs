using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Keys;

public record struct StateKey(Guid CountryId, Guid Id) : IKey;