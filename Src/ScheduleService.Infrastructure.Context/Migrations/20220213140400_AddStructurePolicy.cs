using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleService.Infrastructure.Context.Migrations
{
    public partial class AddStructurePolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_User_UserId",
                table: "AuditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs");

            migrationBuilder.RenameTable(
                name: "AuditLogs",
                newName: "Audit");

            migrationBuilder.RenameIndex(
                name: "IX_AuditLogs_UserId",
                table: "Audit",
                newName: "IX_Audit_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditLogs_PrimaryKey",
                table: "Audit",
                newName: "IX_Audit_PrimaryKey");

            migrationBuilder.RenameIndex(
                name: "IX_AuditLogs_Id",
                table: "Audit",
                newName: "IX_Audit_Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audit",
                table: "Audit",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserUpdateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeleteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsActiveChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_User_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Role_User_UserDeleteId",
                        column: x => x.UserDeleteId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Role_User_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolePolicy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Policy = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserUpdateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeleteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePolicy_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePolicy_User_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolePolicy_User_UserDeleteId",
                        column: x => x.UserDeleteId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolePolicy_User_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserUpdateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeleteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsActiveChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_RoleId",
                        column: x => x.RoleId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserDeleteId",
                        column: x => x.UserDeleteId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_Id",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserCreateId",
                table: "Role",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserDeleteId",
                table: "Role",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserUpdateId",
                table: "Role",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePolicy_Id",
                table: "RolePolicy",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RolePolicy_Policy_RoleId",
                table: "RolePolicy",
                columns: new[] { "Policy", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePolicy_RoleId",
                table: "RolePolicy",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePolicy_UserCreateId",
                table: "RolePolicy",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePolicy_UserDeleteId",
                table: "RolePolicy",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePolicy_UserUpdateId",
                table: "RolePolicy",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_Id",
                table: "UserRole",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserCreateId",
                table: "UserRole",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserDeleteId",
                table: "UserRole",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId_RoleId",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserUpdateId",
                table: "UserRole",
                column: "UserUpdateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_User_UserId",
                table: "Audit",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audit_User_UserId",
                table: "Audit");

            migrationBuilder.DropTable(
                name: "RolePolicy");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audit",
                table: "Audit");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Audit",
                newName: "AuditLogs");

            migrationBuilder.RenameIndex(
                name: "IX_Audit_UserId",
                table: "AuditLogs",
                newName: "IX_AuditLogs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Audit_PrimaryKey",
                table: "AuditLogs",
                newName: "IX_AuditLogs_PrimaryKey");

            migrationBuilder.RenameIndex(
                name: "IX_Audit_Id",
                table: "AuditLogs",
                newName: "IX_AuditLogs_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_User_UserId",
                table: "AuditLogs",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
