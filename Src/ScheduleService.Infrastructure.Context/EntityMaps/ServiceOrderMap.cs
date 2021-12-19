using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class ServiceOrderMap : EntityConfiguration<ServiceOrder>
{
    public override void CustomConfiguration()
    {
        Property(x => x.Status).IsRequired().HasColumnType("int");

        HasOne(x => x.CompanySubsidiary).WithMany().HasForeignKey(x => x.CompanySubsidiaryId).OnDelete(DeleteBehavior.NoAction);
        HasOne(x => x.Customer).WithMany(x => x.ServiceOrders).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);
        HasOne(x => x.ServiceType).WithMany(x => x.ServiceOrders).HasForeignKey(x => x.ServiceTypeId).OnDelete(DeleteBehavior.NoAction);
    }
}
