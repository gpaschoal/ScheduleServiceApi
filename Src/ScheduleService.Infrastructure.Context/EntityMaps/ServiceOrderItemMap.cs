using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class ServiceOrderItemMap : EntityConfiguration<ServiceOrderItem>
{
    public override void CustomConfiguration(EntityTypeBuilder<ServiceOrderItem> builder)
    {
        builder.Property(x => x.Quantity).HasPrecision(10).HasColumnType("int").IsRequired();
        builder.Property(x => x.ServicePrice).HasPrecision(10, 2).HasColumnType("decimal").IsRequired();

        builder.HasOne(x => x.ServiceItem).WithMany(x => x.ServiceOrderItems).HasForeignKey(x => x.ServiceItemId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.ServiceOrder).WithMany(x => x.ServiceOrderItems).HasForeignKey(x => x.ServiceItemId).OnDelete(DeleteBehavior.NoAction);
    }
}
