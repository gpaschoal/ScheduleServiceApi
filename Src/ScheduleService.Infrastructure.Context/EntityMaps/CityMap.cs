using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class CityMap : EntityActivableConfiguration<City>
{
    public override void CustomConfiguration()
    {
        Property(x => x.Name).HasMaxLength(50).HasColumnType("char");
        Property(x => x.ExternalCode).HasMaxLength(50).HasColumnType("char");

        HasOne(x => x.State).WithMany(x => x.Cities).OnDelete(DeleteBehavior.NoAction);
    }
}
