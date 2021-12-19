using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class CompanyMap : EntityActivableConfiguration<Company>
{
    public override void CustomConfiguration()
    {
        Property(x => x.Name).IsRequired().HasColumnType("char").HasMaxLength(100);

        HasMany(x => x.CompanySubsidiaries).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
    }
}
