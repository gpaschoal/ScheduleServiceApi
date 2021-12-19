using ScheduleService.Domain.Model.Entities.Base;
using ScheduleService.Domain.Model.Enums;

namespace ScheduleService.Domain.Model.Entities;

public class ServiceOrder : EntityBase
{
    public ServiceOrder()
    {
        ServiceOrderItems = new List<ServiceOrderItem>();
    }

    public ServiceOrder(Guid customerId, Guid companySubsidiaryId, Guid serviceTypeId) : this()
    {
        CustomerId = customerId;
        CompanySubsidiaryId = companySubsidiaryId;
        ServiceTypeId = serviceTypeId;
        Status = EServiceOrderStatus.Opened;
    }

    public virtual Guid CustomerId { get; private set; }
    public virtual Customer Customer { get; }

    public virtual Guid CompanySubsidiaryId { get; private set; }
    public virtual CompanySubsidiary CompanySubsidiary { get; }

    public virtual Guid ServiceTypeId { get; private set; }
    public virtual ServiceType ServiceType { get; }

    public EServiceOrderStatus Status { get; set; }

    public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; }
}
