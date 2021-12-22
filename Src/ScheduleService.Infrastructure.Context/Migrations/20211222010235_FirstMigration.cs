using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleService.Infrastructure.Context.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "char(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanySubsidiary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    Cnpj = table.Column<string>(type: "char(14)", maxLength: 14, nullable: false),
                    Address_Street = table.Column<string>(type: "char(100)", maxLength: 100, nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "char(60)", maxLength: 60, nullable: false),
                    Address_LocalReference = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Address_Number = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CompanySubsidiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanySubsidiary_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "char(50)", maxLength: 50, nullable: false),
                    ExternalCode = table.Column<string>(type: "char(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
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
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    MinPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    MaxPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ServiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceItem_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "char(50)", maxLength: 50, nullable: false),
                    ExternalCode = table.Column<string>(type: "char(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "char(50)", maxLength: 50, nullable: false),
                    ExternalCode = table.Column<string>(type: "char(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    UserName = table.Column<string>(type: "char(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "char(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telephone1_CodeArea = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Telephone1_PhoneNumber = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Telephone2_CodeArea = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Telephone2_PhoneNumber = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Cellphone1_CodeArea = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Cellphone1_PhoneNumber = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    Cellphone2_CodeArea = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Cellphone2_PhoneNumber = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    Address_Street = table.Column<string>(type: "char(100)", maxLength: 100, nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "char(60)", maxLength: 60, nullable: false),
                    Address_LocalReference = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Address_Number = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
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
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_UserDeleteId",
                        column: x => x.UserDeleteId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    Cnpj = table.Column<string>(type: "char(14)", maxLength: 14, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telephone1_CodeArea = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Telephone1_PhoneNumber = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Telephone2_CodeArea = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Telephone2_PhoneNumber = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Cellphone1_CodeArea = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Cellphone1_PhoneNumber = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    Cellphone2_CodeArea = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Cellphone2_PhoneNumber = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    Address_Street = table.Column<string>(type: "char(100)", maxLength: 100, nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "char(60)", maxLength: 60, nullable: false),
                    Address_LocalReference = table.Column<string>(type: "char(150)", maxLength: 150, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Address_Number = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_User_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_User_UserDeleteId",
                        column: x => x.UserDeleteId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_User_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanySubsidiaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserUpdateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeleteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_CompanySubsidiary_CompanySubsidiaryId",
                        column: x => x.CompanySubsidiaryId,
                        principalTable: "CompanySubsidiary",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrder_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrder_User_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrder_User_UserDeleteId",
                        column: x => x.UserDeleteId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrder_User_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", precision: 10, nullable: false),
                    ServicePrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ServiceOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserUpdateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeleteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrderItem_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrderItem_ServiceOrder_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrderItem_User_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrderItem_User_UserDeleteId",
                        column: x => x.UserDeleteId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrderItem_User_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_Id",
                table: "City",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_City_UserCreateId",
                table: "City",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_City_UserDeleteId",
                table: "City",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_City_UserUpdateId",
                table: "City",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Id",
                table: "Company",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserCreateId",
                table: "Company",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserDeleteId",
                table: "Company",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserUpdateId",
                table: "Company",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubsidiary_CompanyId",
                table: "CompanySubsidiary",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubsidiary_Id",
                table: "CompanySubsidiary",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubsidiary_UserCreateId",
                table: "CompanySubsidiary",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubsidiary_UserDeleteId",
                table: "CompanySubsidiary",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubsidiary_UserUpdateId",
                table: "CompanySubsidiary",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Id",
                table: "Country",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Country_UserCreateId",
                table: "Country",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_UserDeleteId",
                table: "Country",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_UserUpdateId",
                table: "Country",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityId",
                table: "Customer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Id",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserCreateId",
                table: "Customer",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserDeleteId",
                table: "Customer",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserUpdateId",
                table: "Customer",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_Id",
                table: "ServiceItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_ServiceTypeId",
                table: "ServiceItem",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_UserCreateId",
                table: "ServiceItem",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_UserDeleteId",
                table: "ServiceItem",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_UserUpdateId",
                table: "ServiceItem",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_CompanySubsidiaryId",
                table: "ServiceOrder",
                column: "CompanySubsidiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_CustomerId",
                table: "ServiceOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_Id",
                table: "ServiceOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_ServiceTypeId",
                table: "ServiceOrder",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_UserCreateId",
                table: "ServiceOrder",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_UserDeleteId",
                table: "ServiceOrder",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_UserUpdateId",
                table: "ServiceOrder",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderItem_Id",
                table: "ServiceOrderItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderItem_ServiceItemId",
                table: "ServiceOrderItem",
                column: "ServiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderItem_UserCreateId",
                table: "ServiceOrderItem",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderItem_UserDeleteId",
                table: "ServiceOrderItem",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderItem_UserUpdateId",
                table: "ServiceOrderItem",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceType_Id",
                table: "ServiceType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceType_UserCreateId",
                table: "ServiceType",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceType_UserDeleteId",
                table: "ServiceType",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceType_UserUpdateId",
                table: "ServiceType",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_State_Id",
                table: "State",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_State_UserCreateId",
                table: "State",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_UserDeleteId",
                table: "State",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_State_UserUpdateId",
                table: "State",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityId",
                table: "User",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserCreateId",
                table: "User",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserDeleteId",
                table: "User",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserUpdateId",
                table: "User",
                column: "UserUpdateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_UserCreateId",
                table: "Company",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_UserDeleteId",
                table: "Company",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_UserUpdateId",
                table: "Company",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySubsidiary_User_UserCreateId",
                table: "CompanySubsidiary",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySubsidiary_User_UserDeleteId",
                table: "CompanySubsidiary",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySubsidiary_User_UserUpdateId",
                table: "CompanySubsidiary",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_User_UserCreateId",
                table: "Country",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_User_UserDeleteId",
                table: "Country",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_User_UserUpdateId",
                table: "Country",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceType_User_UserCreateId",
                table: "ServiceType",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceType_User_UserDeleteId",
                table: "ServiceType",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceType_User_UserUpdateId",
                table: "ServiceType",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_User_UserCreateId",
                table: "ServiceItem",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_User_UserDeleteId",
                table: "ServiceItem",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_User_UserUpdateId",
                table: "ServiceItem",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_State_User_UserCreateId",
                table: "State",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_State_User_UserDeleteId",
                table: "State",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_State_User_UserUpdateId",
                table: "State",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_User_UserCreateId",
                table: "City",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_User_UserDeleteId",
                table: "City",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_User_UserUpdateId",
                table: "City",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_City_User_UserCreateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_City_User_UserDeleteId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_City_User_UserUpdateId",
                table: "City");

            migrationBuilder.DropTable(
                name: "ServiceOrderItem");

            migrationBuilder.DropTable(
                name: "ServiceItem");

            migrationBuilder.DropTable(
                name: "ServiceOrder");

            migrationBuilder.DropTable(
                name: "CompanySubsidiary");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
