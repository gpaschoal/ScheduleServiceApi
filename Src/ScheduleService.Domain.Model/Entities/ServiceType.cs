using ScheduleService.Domain.Model.Entities.Base;

namespace ScheduleService.Domain.Model.Entities;

public class ServiceType : ActivableEntityBase
{
    public ServiceType()
    {
        ServiceOrders = new List<ServiceOrder>();
        ServiceItems = new List<ServiceItem>();
    }

    public ServiceType(string serviceName) : this()
    {
        ServiceName = serviceName;
    }

    public string ServiceName { get; private set; }

    public virtual ICollection<ServiceOrder> ServiceOrders { get; }
    public virtual ICollection<ServiceItem> ServiceItems { get; }
}
