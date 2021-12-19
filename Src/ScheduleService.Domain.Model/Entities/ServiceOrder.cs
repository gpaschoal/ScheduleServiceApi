using ScheduleService.Domain.Model.Entities.Base;
using ScheduleService.Domain.Model.Enums;

namespace ScheduleService.Domain.Model.Entities;

public class ServiceOrder : EntityBase
{
    public ServiceOrder()
    {
        ServiceOrderItems = new List<ServiceOrderItem>();
    }

    public ServiceOrder(Guid customerId, Guid companyId, Guid companySubsidiaryId, Guid serviceTypeId) : this()
    {
        CustomerId = customerId;
        CompanyId = companyId;
        CompanySubsidiaryId = companySubsidiaryId;
        ServiceTypeId = serviceTypeId;
        Status = EServiceOrderStatus.Opened;
    }

    public virtual Guid CustomerId { get; private set; }
    public virtual Customer Customer { get; }

    public virtual Guid CompanyId { get; private set; }
    public virtual Company Company { get; }

    public virtual Guid CompanySubsidiaryId { get; private set; }
    public virtual CompanySubsidiary CompanySubsidiary { get; }

    public virtual Guid ServiceTypeId { get; private set; }
    public virtual ServiceType ServiceType { get; }

    public EServiceOrderStatus Status { get; set; }

    public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; }
}
