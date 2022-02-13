using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class RoleMap : EntityActivableConfiguration<Role>
{
    public override void CustomConfiguration(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.Name).HasColumnType("char").HasMaxLength(150);
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
        builder.HasMany(x => x.RolePolicies).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
    }
}
