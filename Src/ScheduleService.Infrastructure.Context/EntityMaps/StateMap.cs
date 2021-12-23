using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class StateMap : EntityActivableConfiguration<State>
{
    public override void CustomConfiguration(EntityTypeBuilder<State> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50).HasColumnType("char");
        builder.Property(x => x.ExternalCode).HasMaxLength(50).HasColumnType("char");

        builder.HasMany(x => x.Cities).WithOne(x => x.State).HasForeignKey(x => x.StateId).OnDelete(DeleteBehavior.NoAction);
    }
}
