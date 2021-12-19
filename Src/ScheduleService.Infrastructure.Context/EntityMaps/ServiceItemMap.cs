using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class ServiceItemMap : EntityActivableConfiguration<ServiceItem>
{
    public override void CustomConfiguration()
    {
        Property(x => x.ServiceName).IsRequired().HasColumnType("char").HasMaxLength(150);
        Property(x => x.Description).IsRequired().HasColumnType("char").HasMaxLength(150);
        Property(x => x.MinPrice).IsRequired().HasColumnType("decimal").HasPrecision(10, 2);
        Property(x => x.MaxPrice).IsRequired().HasColumnType("decimal").HasPrecision(10, 2);

        HasOne(x => x.ServiceType).WithMany().HasForeignKey(x => x.ServiceTypeId).OnDelete(DeleteBehavior.NoAction);
        HasMany(x => x.ServiceOrderItems).WithOne(x => x.ServiceItem).HasForeignKey(x => x.ServiceItemId).OnDelete(DeleteBehavior.NoAction);
    }
}
