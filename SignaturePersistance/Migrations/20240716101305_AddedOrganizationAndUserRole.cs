using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignaturePersistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrganizationAndUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("743be124-595f-4880-a2db-d657e5dd86c2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("89990cf6-e9d9-49c5-a86d-199e815a7739"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c025a8b3-4fab-45d8-86c7-aaa506b77270"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Stauts",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNO = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CommercialName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JuridicalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JuridicalAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "ApiKey", "CommercialName", "CreateDate", "IDNO", "JuridicalAddress", "JuridicalName", "LastModified", "PhoneNumber", "Status" },
                values: new object[] { new Guid("38284448-d96a-426f-9088-c5980fcd68e4"), null, "LVBGroup", new DateTime(2024, 7, 16, 13, 13, 4, 508, DateTimeKind.Local).AddTicks(5362), "0000000000001", "Address1 Ap.1", "LVBGroup", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateDate", "DateOfBirth", "Email", "FirstName", "Gender", "IDNP", "LastModified", "LastName", "OrganizationId", "Password", "PhoneNumber", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("67149dfa-f1a2-48c8-9d16-f2baf4d6bbea"), "Planet Earth", new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(457), new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(178), "admin@lvbgroup.com", "First", 2, "0000000000001", new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(739), "User", new Guid("38284448-d96a-426f-9088-c5980fcd68e4"), "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", "69000001", 0, 1 },
                    { new Guid("7df68256-6096-4003-a774-2a7382ded382"), "Planet Earth", new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(1595), new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(1587), "user@lvbgroup.com", "Second", 2, "0000000000002", new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(1597), "User", new Guid("38284448-d96a-426f-9088-c5980fcd68e4"), "b512d97e7cbf97c273e4db073bbb547aa65a84589227f8f3d9e4a72b9372a24d", "69000002", 0, 1 },
                    { new Guid("874ee990-e39e-4d00-b30a-d0ccbd3280ae"), "Planet Earth", new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(1629), new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(1627), "user@lvbgroup.com", "Third", 2, "0000000000003", new DateTime(2024, 7, 16, 13, 13, 4, 515, DateTimeKind.Local).AddTicks(1630), "User", new Guid("38284448-d96a-426f-9088-c5980fcd68e4"), "b512d97e7cbf97c273e4db073bbb547aa65a84589227f8f3d9e4a72b9372a24d", "69000003", 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Id",
                table: "Organizations",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67149dfa-f1a2-48c8-9d16-f2baf4d6bbea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7df68256-6096-4003-a774-2a7382ded382"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("874ee990-e39e-4d00-b30a-d0ccbd3280ae"));

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Stauts",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateDate", "DateOfBirth", "Email", "FirstName", "Gender", "IDNP", "LastModified", "LastName", "Password", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("743be124-595f-4880-a2db-d657e5dd86c2"), "Planet Earth", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7530), new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7528), "user@lvbgroup.com", "Third", 0, "0000000000003", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7532), "User", "b512d97e7cbf97c273e4db073bbb547aa65a84589227f8f3d9e4a72b9372a24d", "69000003", 1 },
                    { new Guid("89990cf6-e9d9-49c5-a86d-199e815a7739"), "Planet Earth", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(5866), new DateTime(2024, 4, 17, 21, 36, 52, 438, DateTimeKind.Local).AddTicks(5819), "admin@lvbgroup.com", "First", 0, "0000000000001", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(6415), "User", "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", "69000001", 1 },
                    { new Guid("c025a8b3-4fab-45d8-86c7-aaa506b77270"), "Planet Earth", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7498), new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7492), "user@lvbgroup.com", "Second", 0, "0000000000002", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7499), "User", "b512d97e7cbf97c273e4db073bbb547aa65a84589227f8f3d9e4a72b9372a24d", "69000002", 1 }
                });
        }
    }
}
