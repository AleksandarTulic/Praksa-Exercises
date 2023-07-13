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
            migrationBuilder.CreateTable(
                name: "CollegeYears",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Index = table.Column<string>(type: "text", nullable: false),
                    CollegeYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Birthday = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Enrolled = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_College_Year",
                        column: x => x.CollegeYearId,
                        principalTable: "CollegeYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CollegeYears",
                columns: new[] { "Id", "Year" },
                values: new object[,]
                {
                    { new Guid("09878544-8945-4bb7-82c9-d567a2f632a4"), 1 },
                    { new Guid("3cf3421b-7641-4709-bf90-b5f2f2226df4"), 4 },
                    { new Guid("7a0e332a-f33e-4112-93ce-4772ec1b6191"), 3 },
                    { new Guid("c05db07a-5749-4278-886e-e2352907ccc3"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeYearId",
                table: "Students",
                column: "CollegeYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "CollegeYears");
        }
    }
}
