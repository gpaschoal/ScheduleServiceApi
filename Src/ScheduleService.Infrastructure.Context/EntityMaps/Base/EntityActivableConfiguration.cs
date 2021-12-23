using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps.Base;

public abstract class EntityActivableConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : ActivableEntityBase
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        CustomConfiguration(builder);

        base.Configure(builder);

        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.IsActiveChangeDate).IsRequired();
    }

    public override abstract void CustomConfiguration(EntityTypeBuilder<TEntity> builder);
}
