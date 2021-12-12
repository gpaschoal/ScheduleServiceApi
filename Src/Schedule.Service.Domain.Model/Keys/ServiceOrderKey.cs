using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Keys;

public record struct ServiceOrderKey(Guid CompanyId, Guid CompanySubsidiaryId, Guid CustomerId, Guid Id) : IKey;