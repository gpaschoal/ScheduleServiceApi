using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class ServiceItemMap : EntityActivableConfiguration<ServiceItem>
{
    public override void CustomConfiguration(EntityTypeBuilder<ServiceItem> builder)
    {
        builder.Property(x => x.ServiceName).IsRequired().HasColumnType("char").HasMaxLength(150);
        builder.Property(x => x.Description).IsRequired().HasColumnType("char").HasMaxLength(150);
        builder.Property(x => x.MinPrice).IsRequired().HasColumnType("decimal").HasPrecision(10, 2);
        builder.Property(x => x.MaxPrice).IsRequired().HasColumnType("decimal").HasPrecision(10, 2);

        builder.HasOne(x => x.ServiceType).WithMany().HasForeignKey(x => x.ServiceTypeId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(x => x.ServiceOrderItems).WithOne(x => x.ServiceItem).HasForeignKey(x => x.ServiceItemId).OnDelete(DeleteBehavior.NoAction);
    }
}
