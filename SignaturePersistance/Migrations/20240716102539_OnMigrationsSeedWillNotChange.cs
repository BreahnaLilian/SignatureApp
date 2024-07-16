using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignaturePersistance.Migrations
{
    /// <inheritdoc />
    public partial class OnMigrationsSeedWillNotChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("38284448-d96a-426f-9088-c5980fcd68e4"));

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "ApiKey", "CommercialName", "CreateDate", "IDNO", "JuridicalAddress", "JuridicalName", "LastModified", "PhoneNumber", "Status" },
                values: new object[] { new Guid("9ee896ee-cb8a-4df4-949b-b6fcc81d76f2"), null, "LVBGroup", new DateTime(2024, 7, 16, 13, 25, 38, 612, DateTimeKind.Local).AddTicks(1560), "0000000000001", "Address1 Ap.1", "LVBGroup", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateDate", "DateOfBirth", "Email", "FirstName", "Gender", "IDNP", "LastModified", "LastName", "OrganizationId", "Password", "PhoneNumber", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("1f7bddde-fe95-4f29-878d-8e6efca243f1"), "Planet Earth", new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(7152), new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(7150), "user@lvbgroup.com", "Third", 2, "0000000000003", new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(7154), "User", new Guid("9ee896ee-cb8a-4df4-949b-b6fcc81d76f2"), "b512d97e7cbf97c273e4db073bbb547aa65a84589227f8f3d9e4a72b9372a24d", "69000003", 0, 1 },
                    { new Guid("61d001ab-1553-4b8a-af2a-379d1540ed5a"), "Planet Earth", new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(7118), new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(7111), "user@lvbgroup.com", "Second", 2, "0000000000002", new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(7120), "User", new Guid("9ee896ee-cb8a-4df4-949b-b6fcc81d76f2"), "b512d97e7cbf97c273e4db073bbb547aa65a84589227f8f3d9e4a72b9372a24d", "69000002", 0, 1 },
                    { new Guid("e631e603-266c-462a-87d3-f606c8111559"), "Planet Earth", new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(5994), new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(5712), "admin@lvbgroup.com", "First", 2, "0000000000001", new DateTime(2024, 7, 16, 13, 25, 38, 618, DateTimeKind.Local).AddTicks(6281), "User", new Guid("9ee896ee-cb8a-4df4-949b-b6fcc81d76f2"), "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", "69000001", 0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f7bddde-fe95-4f29-878d-8e6efca243f1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61d001ab-1553-4b8a-af2a-379d1540ed5a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e631e603-266c-462a-87d3-f606c8111559"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("9ee896ee-cb8a-4df4-949b-b6fcc81d76f2"));

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
        }
    }
}
