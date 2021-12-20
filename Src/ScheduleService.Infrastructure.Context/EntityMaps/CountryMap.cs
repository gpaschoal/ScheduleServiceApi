using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class CountryMap : EntityActivableConfiguration<Country>
{
    public override void CustomConfiguration(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50).HasColumnType("char");
        builder.Property(x => x.ExternalCode).HasMaxLength(50).HasColumnType("char");

        builder.HasMany(x => x.States).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.NoAction);
    }
}
