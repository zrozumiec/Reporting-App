using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingApp.Infrastructure.Migrations
{
    public partial class Addstartendtimeforsolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpectedEndTime",
                table: "FailureSolutions",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpectedStartTime",
                table: "FailureSolutions",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedEndTime",
                table: "FailureSolutions");

            migrationBuilder.DropColumn(
                name: "ExpectedStartTime",
                table: "FailureSolutions");
        }
    }
}
