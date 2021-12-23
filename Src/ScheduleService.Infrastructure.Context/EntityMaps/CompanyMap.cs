using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class CompanyMap : EntityActivableConfiguration<Company>
{
    public override void CustomConfiguration(EntityTypeBuilder<Company> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnType("char").HasMaxLength(100);

        builder.HasMany(x => x.CompanySubsidiaries).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
    }
}
