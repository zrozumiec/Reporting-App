using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
#pragma warning disable SA1118 // Parameter should not span multiple lines
#pragma warning disable SA1600 // Partial elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace ReportingApp.Infrastructure.Migrations
{
    public partial class FailureStatusDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FailureStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Reserved" },
                    { 3, "In progress" },
                    { 4, "Done" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FailureStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FailureStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FailureStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FailureStatuses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
