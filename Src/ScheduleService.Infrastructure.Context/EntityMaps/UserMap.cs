using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class UserMap : EntityActivableConfiguration<User>
{
    public override void CustomConfiguration(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName).HasColumnType("char").HasMaxLength(150);
        builder.Property(x => x.LastName).HasColumnType("char").HasMaxLength(150);
        builder.Property(x => x.UserName).HasColumnType("char").HasMaxLength(50);
        builder.Property(x => x.Password).HasColumnType("char").HasMaxLength(100);
        builder.Property(x => x.Email).HasColumnType("char").HasMaxLength(100);

        builder.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.NoAction);

        builder.OwnsOne(x => x.Cpf, x => x.Property(p => p.Value).HasColumnName("Cpf").HasMaxLength(11).HasColumnType("char").IsRequired());

        builder.OwnsOne(x => x.Telephone1, x =>
        {
            x.Property(x => x.CodeArea).HasMaxLength(3).HasColumnType("char").IsRequired();
            x.Property(x => x.PhoneNumber).HasMaxLength(10).HasColumnType("char").IsRequired();
        });
        builder.OwnsOne(x => x.Telephone2, x =>
        {
            x.Property(x => x.CodeArea).HasMaxLength(3).HasColumnType("char").IsRequired();
            x.Property(x => x.PhoneNumber).HasMaxLength(10).HasColumnType("char").IsRequired();
        });

        builder.OwnsOne(x => x.Cellphone1, x =>
        {
            x.Property(x => x.CodeArea).HasMaxLength(3).HasColumnType("char").IsRequired();
            x.Property(x => x.PhoneNumber).HasMaxLength(11).HasColumnType("char").IsRequired();
        });
        builder.OwnsOne(x => x.Cellphone2, x =>
        {
            x.Property(x => x.CodeArea).HasMaxLength(3).HasColumnType("char").IsRequired();
            x.Property(x => x.PhoneNumber).HasMaxLength(11).HasColumnType("char").IsRequired();
        });

        builder.OwnsOne(x => x.Address, x =>
        {
            x.Property(x => x.Street).HasMaxLength(100).HasColumnType("char").IsRequired();
            x.Property(x => x.Neighborhood).HasMaxLength(60).HasColumnType("char").IsRequired();
            x.Property(x => x.LocalReference).HasMaxLength(150).HasColumnType("char").IsRequired();
            x.Property(x => x.ZipCode).HasMaxLength(10).HasColumnType("char").IsRequired();
            x.Property(x => x.Number).HasMaxLength(10).HasColumnType("char").IsRequired();
        });
    }
}
