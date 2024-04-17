using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignaturePersistance.Migrations
{
    /// <inheritdoc />
    public partial class _InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Size = table.Column<int>(type: "int", maxLength: 1024, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Stauts = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SignedBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IDNP = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "SignatureFilesToUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureFilesToUsers", x => new { x.UserId, x.FileId });
                    table.ForeignKey(
                        name: "FK_SignatureFilesToUsers_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SignatureFilesToUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateDate", "DateOfBirth", "Email", "FirstName", "Gender", "IDNP", "LastModified", "LastName", "Password", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("743be124-595f-4880-a2db-d657e5dd86c2"), "Planet Earth", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7530), new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7528), "user@lvbgroup.com", "Third", 0, "0000000000003", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7532), "User", "b512d97e7cbf97c273e4db073bbb547aa65a84589227f8f3d9e4a72b9372a24d", "69000003", 1 },
                    { new Guid("89990cf6-e9d9-49c5-a86d-199e815a7739"), "Planet Earth", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(5866), new DateTime(2024, 4, 17, 21, 36, 52, 438, DateTimeKind.Local).AddTicks(5819), "admin@lvbgroup.com", "First", 0, "0000000000001", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(6415), "User", "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", "69000001", 1 },
                    { new Guid("c025a8b3-4fab-45d8-86c7-aaa506b77270"), "Planet Earth", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7498), new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7492), "user@lvbgroup.com", "Second", 0, "0000000000002", new DateTime(2024, 4, 17, 21, 36, 52, 439, DateTimeKind.Local).AddTicks(7499), "User", "b512d97e7cbf97c273e4db073bbb547aa65a84589227f8f3d9e4a72b9372a24d", "69000002", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SignatureFilesToUsers_FileId",
                table: "SignatureFilesToUsers",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignatureFilesToUsers");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
