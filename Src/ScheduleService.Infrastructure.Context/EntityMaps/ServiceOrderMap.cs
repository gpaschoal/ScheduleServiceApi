using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class ServiceOrderMap : EntityConfiguration<ServiceOrder>
{
    public override void CustomConfiguration(EntityTypeBuilder<ServiceOrder> builder)
    {
        builder.Property(x => x.Status).IsRequired().HasColumnType("int");

        builder.HasOne(x => x.CompanySubsidiary).WithMany().HasForeignKey(x => x.CompanySubsidiaryId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Customer).WithMany(x => x.ServiceOrders).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.ServiceType).WithMany(x => x.ServiceOrders).HasForeignKey(x => x.ServiceTypeId).OnDelete(DeleteBehavior.NoAction);
    }
}
