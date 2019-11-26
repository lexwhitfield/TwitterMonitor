using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterMonitor.DataModels.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Member",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeath",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Member",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Member");
        }
    }
}
