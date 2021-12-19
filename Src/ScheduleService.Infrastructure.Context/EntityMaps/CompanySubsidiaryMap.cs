﻿using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class CompanySubsidiaryMap : EntityActivableConfiguration<CompanySubsidiary>
{
    public override void CustomConfiguration()
    {
        Property(x => x.Name).IsRequired().HasColumnType("char").HasMaxLength(150);

        OwnsOne(x => x.Cnpj, x => x.Property(p => p.Value).HasColumnName("Cnpj").HasMaxLength(14).HasColumnType("char").IsRequired());

        OwnsOne(x => x.Address, x =>
        {
            x.Property(x => x.Street).HasMaxLength(100).HasColumnType("char").IsRequired();
            x.Property(x => x.Neighborhood).HasMaxLength(60).HasColumnType("char").IsRequired();
            x.Property(x => x.LocalReference).HasMaxLength(150).HasColumnType("char").IsRequired();
            x.Property(x => x.ZipCode).HasMaxLength(10).HasColumnType("char").IsRequired();
            x.Property(x => x.Number).HasMaxLength(10).HasColumnType("char").IsRequired();
        });

        HasOne(x => x.Company).WithMany(x => x.CompanySubsidiaries).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.NoAction);
    }
}
