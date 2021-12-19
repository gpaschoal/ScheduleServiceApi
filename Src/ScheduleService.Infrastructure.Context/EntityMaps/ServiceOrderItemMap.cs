using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class ServiceOrderItemMap : EntityConfiguration<ServiceOrderItem>
{
    public override void CustomConfiguration()
    {
        Property(x => x.Quantity).HasPrecision(10).HasColumnType("int").IsRequired();
        Property(x => x.ServicePrice).HasPrecision(10, 2).HasColumnType("decimal").IsRequired();

        HasOne(x => x.ServiceItem).WithMany(x => x.ServiceOrderItems).HasForeignKey(x => x.ServiceItemId).OnDelete(DeleteBehavior.NoAction);
        HasOne(x => x.ServiceOrder).WithMany(x => x.ServiceOrderItems).HasForeignKey(x => x.ServiceItemId).OnDelete(DeleteBehavior.NoAction);
    }
}
