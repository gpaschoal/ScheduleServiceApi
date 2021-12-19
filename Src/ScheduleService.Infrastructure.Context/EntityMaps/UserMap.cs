using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities;
using ScheduleService.Infrastructure.Context.EntityMaps.Base;

namespace ScheduleService.Infrastructure.Context.EntityMaps;

public class UserMap : EntityActivableConfiguration<User>
{
    public override void CustomConfiguration()
    {
        Property(x => x.FirstName).HasColumnType("char").HasMaxLength(150);
        Property(x => x.LastName).HasColumnType("char").HasMaxLength(150);
        Property(x => x.UserName).HasColumnType("char").HasMaxLength(50);
        Property(x => x.Password).HasColumnType("char").HasMaxLength(100);

        HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.NoAction);

        OwnsOne(x => x.Cpf, x => x.Property(p => p.Value).HasColumnName("Cpf").HasMaxLength(11).HasColumnType("char").IsRequired());

        OwnsOne(x => x.Telephone1, x =>
        {
            x.Property(x => x.CodeArea).HasMaxLength(3).HasColumnType("char").IsRequired();
            x.Property(x => x.PhoneNumber).HasMaxLength(10).HasColumnType("char").IsRequired();
        });
        OwnsOne(x => x.Telephone2, x =>
        {
            x.Property(x => x.CodeArea).HasMaxLength(3).HasColumnType("char").IsRequired();
            x.Property(x => x.PhoneNumber).HasMaxLength(10).HasColumnType("char").IsRequired();
        });

        OwnsOne(x => x.Cellphone1, x =>
        {
            x.Property(x => x.CodeArea).HasMaxLength(3).HasColumnType("char").IsRequired();
            x.Property(x => x.PhoneNumber).HasMaxLength(11).HasColumnType("char").IsRequired();
        });
        OwnsOne(x => x.Cellphone2, x =>
        {
            x.Property(x => x.CodeArea).HasMaxLength(3).HasColumnType("char").IsRequired();
            x.Property(x => x.PhoneNumber).HasMaxLength(11).HasColumnType("char").IsRequired();
        });

        OwnsOne(x => x.Address, x =>
        {
            x.Property(x => x.Street).HasMaxLength(100).HasColumnType("char").IsRequired();
            x.Property(x => x.Neighborhood).HasMaxLength(60).HasColumnType("char").IsRequired();
            x.Property(x => x.LocalReference).HasMaxLength(150).HasColumnType("char").IsRequired();
            x.Property(x => x.ZipCode).HasMaxLength(10).HasColumnType("char").IsRequired();
            x.Property(x => x.Number).HasMaxLength(10).HasColumnType("char").IsRequired();
        });
    }
}
