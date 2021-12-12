using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Keys;

public record struct ServiceItemKey(Guid CompanyId, Guid CompanySubsidiaryId, Guid Id) : IKey;