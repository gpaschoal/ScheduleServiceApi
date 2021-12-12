using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Keys;

public record struct ServiceOrderItemKey(Guid CompanyId, Guid CompanySubsidiaryId, Guid CustomerId, Guid ServiceOrderId, Guid Id) : IKey;
