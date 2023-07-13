using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentService.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollegeYear",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Index = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Birthday = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Enrolled = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CollegeYearId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_CollegeYear",
                        column: x => x.CollegeYearId,
                        principalTable: "CollegeYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Student_CollegeYearId",
                table: "Student",
                column: "CollegeYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "CollegeYear");
        }
    }
}
