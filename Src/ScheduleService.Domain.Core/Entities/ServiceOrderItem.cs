﻿using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Core.Entities;

public class ServiceOrderItem : EntityBase
{
    public ServiceOrderItem(Guid serviceItemId, int quantity, decimal servicePrice, Guid serviceOrderId)
    {
        ServiceItemId = serviceItemId;
        Quantity = quantity;
        ServicePrice = servicePrice;
        ServiceOrderId = serviceOrderId;
    }

    public Guid ServiceItemId { get; private set; }
    public virtual ServiceItem ServiceItem { get; }
    public int Quantity { get; private set; }
    public decimal ServicePrice { get; private set; }
    public Guid ServiceOrderId { get; private set; }
    public virtual ServiceOrder ServiceOrder { get; }
}
