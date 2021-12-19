using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Model.Entities.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps.Base;

public abstract class EntityActivableConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : ActivableEntityBase
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        CustomConfiguration();

        base.Configure(builder);

        builder.Property(x => x.IsActive).IsRequired().HasColumnType("bit");
        builder.Property(x => x.IsActiveChangeDate).IsRequired().HasColumnType("Datetime");
    }

    public override abstract void CustomConfiguration();
}
