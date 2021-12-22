using Microsoft.EntityFrameworkCore.Migrations;
using ScheduleService.Domain.Model.Entities;

#nullable disable

namespace ScheduleService.Infrastructure.Context.Migrations
{
    public partial class SeedData : Migration
    {
        private static (User, Guid) MakeUser()
        {
            var userId = Guid.Parse("41ec910b-e61a-4471-8d78-ded12db5d124");
            User user = new(
                firstName: "Admin",
                lastName: "Admin",
                userName: "Admin",
                password: "nhkfOTllc50xMQOu/zA4RLFSgGgaOr9TgYmEWGZynO0=",
                cpf: new("11111111111"),
                cityId: null,
                telephone1: null,
                telephone2: null,
                cellphone1: null,
                cellphone2: null,
                address: null);

            return (user, userId);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            (User user, Guid id) = MakeUser();
            _ = migrationBuilder.InsertData(
                table: "User",
                columns: new[] { nameof(user.Id), nameof(user.FirstName), nameof(user.LastName), nameof(user.UserName), nameof(user.Password), nameof(user.Cpf), nameof(user.UserCreateId), nameof(user.IsActive), nameof(user.CreatedAt), nameof(user.IsActiveChangeDate) },
                values: new object[] { id, user.FirstName, user.LastName, user.UserName, user.Password, user.Cpf.Value, id, true, DateTime.Now, DateTime.Now });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            (_, Guid id) = MakeUser();
            migrationBuilder.DeleteData(table: "User", keyColumn: "Id", keyValue: id);
        }
    }
}
