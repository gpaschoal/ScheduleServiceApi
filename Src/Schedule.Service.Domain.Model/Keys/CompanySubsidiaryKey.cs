using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Keys;

public record struct CompanySubsidiaryKey(Guid CompanyId, Guid Id) : IKey;