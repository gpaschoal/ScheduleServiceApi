using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class ServiceTypeMap : EntityActivableConfiguration<ServiceType>
{
    public override void CustomConfiguration(EntityTypeBuilder<ServiceType> builder)
    {
        builder.Property(x => x.ServiceName).HasColumnType("char").IsRequired().HasMaxLength(150);
    }
}
