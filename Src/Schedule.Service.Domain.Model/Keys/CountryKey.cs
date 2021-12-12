using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Keys;

public record struct CountryKey(Guid Id) : IKey;
