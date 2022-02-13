using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class AuditMap : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.ToTable("Audit");

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id);

        builder.HasIndex(x => x.PrimaryKey);
        builder.Property(x => x.PrimaryKey);

        builder.HasOne(x => x.User).WithMany()
            .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.Type).HasColumnType("int").IsRequired();

        builder.Property(x => x.TableName).HasColumnType("char").HasMaxLength(50).IsRequired();

        builder.Property(x => x.AuditTime).IsRequired();

        builder.Property(x => x.OldValues).IsRequired();

        builder.Property(x => x.NewValues).IsRequired();
    }
}
