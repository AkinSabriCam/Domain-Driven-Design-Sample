using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise.EntityFramework.Migrations
{
    public partial class Updated_Field_Buses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "BusDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "BusDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "BusDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "BusDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
