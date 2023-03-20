using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
#pragma warning disable SA1600 // Partial elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace ReportingApp.Infrastructure.Migrations
{
    public partial class FailureSolutionFixTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpectedCoastMin",
                table: "FailureSolutions",
                newName: "ExpectedCostMin");

            migrationBuilder.RenameColumn(
                name: "ExpectedCoastMax",
                table: "FailureSolutions",
                newName: "ExpectedCostMax");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpectedCostMin",
                table: "FailureSolutions",
                newName: "ExpectedCoastMin");

            migrationBuilder.RenameColumn(
                name: "ExpectedCostMax",
                table: "FailureSolutions",
                newName: "ExpectedCoastMax");
        }
    }
}
