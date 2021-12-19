using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class ServiceTypeMap : EntityActivableConfiguration<ServiceType>
{
    public override void CustomConfiguration()
    {
        Property(x => x.ServiceName).HasColumnType("char").IsRequired().HasMaxLength(150);
    }
}
