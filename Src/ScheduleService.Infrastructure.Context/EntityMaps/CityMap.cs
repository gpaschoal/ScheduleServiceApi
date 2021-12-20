using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class CityMap : EntityActivableConfiguration<City>
{
    public override void CustomConfiguration(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50).HasColumnType("char");
        builder.Property(x => x.ExternalCode).HasMaxLength(50).HasColumnType("char");

        builder.HasOne(x => x.State).WithMany(x => x.Cities).OnDelete(DeleteBehavior.NoAction);
    }
}
