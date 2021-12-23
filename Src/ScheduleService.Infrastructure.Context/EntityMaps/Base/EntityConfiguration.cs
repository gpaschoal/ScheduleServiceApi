using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps.Base;

public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        CustomConfiguration(builder);

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id);

        builder.HasOne(x => x.UserCreate).WithMany()
            .HasForeignKey(x => x.UserCreateId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.UserUpdate).WithMany()
           .HasForeignKey(x => x.UserUpdateId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.UserDelete).WithMany()
           .HasForeignKey(x => x.UserDeleteId).OnDelete(DeleteBehavior.NoAction);
    }

    public abstract void CustomConfiguration(EntityTypeBuilder<TEntity> builder);
}
