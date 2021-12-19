using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class CountryMap : EntityActivableConfiguration<Country>
{
    public override void CustomConfiguration()
    {
        Property(x => x.Name).HasMaxLength(50).HasColumnType("char");
        Property(x => x.ExternalCode).HasMaxLength(50).HasColumnType("char");

        HasMany(x => x.States).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.NoAction);
    }
}
