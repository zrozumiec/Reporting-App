using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
#pragma warning disable SA1118 // Parameter should not span multiple lines
#pragma warning disable SA1600 // Partial elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace ReportingApp.Infrastructure.Migrations
{
    public partial class FailureCategoryDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FailureCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electric" },
                    { 2, "Mechanic" },
                    { 3, "Pneumatic" },
                    { 4, "SoftwarePLC" },
                    { 5, "Robotic" },
                    { 6, "Other" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FailureCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FailureCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FailureCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FailureCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FailureCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FailureCategories",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
