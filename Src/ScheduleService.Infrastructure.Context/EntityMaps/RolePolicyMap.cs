using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class RolePolicyMap : EntityAuditConfiguration<RolePolicy>
{
    public override void CustomConfiguration(EntityTypeBuilder<RolePolicy> builder)
    {
        builder.Property(x => x.Policy).HasColumnType("char").HasMaxLength(150);
        builder.HasIndex(x => new { x.Policy, x.RoleId }).IsUnique();

        builder.HasOne(x => x.Role).WithMany(x => x.RolePolicies).HasForeignKey(x => x.RoleId);
    }
}
