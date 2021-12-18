using Schedule.Service.Domain.Model.Entities.Base;

namespace Schedule.Service.Domain.Model.Entities;

public class ServiceItem : ActivableEntityBase
{
    public ServiceItem()
    {
        ServiceOrderItems = new List<ServiceOrderItem>();
    }

    public ServiceItem(string serviceName, string description, decimal minPrice, decimal maxPrice, Guid serviceTypeId) : this()
    {
        ServiceName = serviceName;
        Description = description;
        MinPrice = minPrice;
        MaxPrice = maxPrice;
        ServiceTypeId = serviceTypeId;
    }

    public string ServiceName { get; private set; }
    public string Description { get; private set; }
    public decimal MinPrice { get; private set; }
    public decimal MaxPrice { get; private set; }

    public virtual Guid ServiceTypeId { get; private set; }
    public virtual ServiceType ServiceType { get; }

    public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; }
}
