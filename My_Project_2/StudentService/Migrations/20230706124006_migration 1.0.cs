using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentService.Migrations
{
    /// <inheritdoc />
    public partial class migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("006203e9-09ba-425e-9351-f8614b6f1eeb"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("972195a5-c82d-4732-840d-598025372633"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("d00995b3-d037-4683-87be-1cfc4ef02f7d"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("e7d0e068-351e-450e-bcc9-6aa29a765fe9"));

            migrationBuilder.InsertData(
                table: "CollegeYear",
                columns: new[] { "Id", "Year" },
                values: new object[,]
                {
                    { new Guid("563104cd-da92-4d00-81af-1f9c21c3a738"), 1 },
                    { new Guid("84203ba8-dab9-44b5-b089-f7340f2dfb92"), 3 },
                    { new Guid("9a7d7ebc-d68f-4417-87fa-d217e624b1f2"), 4 },
                    { new Guid("a916ea1d-406d-4688-86e4-b4e74b134d69"), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("563104cd-da92-4d00-81af-1f9c21c3a738"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("84203ba8-dab9-44b5-b089-f7340f2dfb92"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("9a7d7ebc-d68f-4417-87fa-d217e624b1f2"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("a916ea1d-406d-4688-86e4-b4e74b134d69"));

            migrationBuilder.InsertData(
                table: "CollegeYear",
                columns: new[] { "Id", "Year" },
                values: new object[,]
                {
                    { new Guid("006203e9-09ba-425e-9351-f8614b6f1eeb"), 3 },
                    { new Guid("972195a5-c82d-4732-840d-598025372633"), 4 },
                    { new Guid("d00995b3-d037-4683-87be-1cfc4ef02f7d"), 2 },
                    { new Guid("e7d0e068-351e-450e-bcc9-6aa29a765fe9"), 1 }
                });
        }
    }
}
