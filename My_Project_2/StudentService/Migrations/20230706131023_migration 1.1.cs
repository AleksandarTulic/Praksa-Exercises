using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentService.Migrations
{
    /// <inheritdoc />
    public partial class migration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("16b12c21-a061-4940-9fb5-f2272a18aaeb"), 4 },
                    { new Guid("32e71d2e-859b-4a31-889b-14965c80f179"), 1 },
                    { new Guid("83c00dfc-8832-41ac-8ac6-78d956cb6fad"), 6 },
                    { new Guid("b150e415-4e1f-4ffd-a13a-5a5de2bf03ab"), 2 },
                    { new Guid("d319c73b-bf4a-46a2-9d8e-e0e72eb307b8"), 3 },
                    { new Guid("f831ba0a-9f06-47c3-a46f-b350a07c203e"), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("16b12c21-a061-4940-9fb5-f2272a18aaeb"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("32e71d2e-859b-4a31-889b-14965c80f179"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("83c00dfc-8832-41ac-8ac6-78d956cb6fad"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("b150e415-4e1f-4ffd-a13a-5a5de2bf03ab"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("d319c73b-bf4a-46a2-9d8e-e0e72eb307b8"));

            migrationBuilder.DeleteData(
                table: "CollegeYear",
                keyColumn: "Id",
                keyValue: new Guid("f831ba0a-9f06-47c3-a46f-b350a07c203e"));

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
    }
}
