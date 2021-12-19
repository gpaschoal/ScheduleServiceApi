using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Model.Entities.Base;
using System.Linq.Expressions;

namespace ScheduleService.Infrastructure.Context.EntityMaps.Base;

public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
{
    private EntityTypeBuilder<TEntity> _builder;
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        _builder = builder;
        CustomConfiguration();

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id);

        HasOne(x => x.UserCreate).WithMany()
            .HasForeignKey(x => x.UserCreateId).OnDelete(DeleteBehavior.NoAction);

        HasOne(x => x.UserUpdate).WithMany()
           .HasForeignKey(x => x.UserUpdateId).OnDelete(DeleteBehavior.NoAction);

        HasOne(x => x.UserDelete).WithMany()
           .HasForeignKey(x => x.UserDeleteId).OnDelete(DeleteBehavior.NoAction);
    }

    public abstract void CustomConfiguration();

    public PropertyBuilder<TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression) => _builder.Property(propertyExpression);

    public ReferenceNavigationBuilder<TEntity, TRelatedEntity> HasOne<TRelatedEntity>(Expression<Func<TEntity, TRelatedEntity?>>? navigationExpression = null) where TRelatedEntity : class
        => _builder.HasOne(navigationExpression);

    public virtual CollectionNavigationBuilder<TEntity, TRelatedEntity> HasMany<TRelatedEntity>(Expression<Func<TEntity, IEnumerable<TRelatedEntity>?>>? navigationExpression = null) where TRelatedEntity : class
        => _builder.HasMany(navigationExpression);

    public virtual EntityTypeBuilder<TEntity> OwnsOne<TRelatedEntity>(Expression<Func<TEntity, TRelatedEntity?>> navigationExpression, Action<OwnedNavigationBuilder<TEntity, TRelatedEntity>> buildAction) where TRelatedEntity : class
        => _builder.OwnsOne(navigationExpression, buildAction);
}
