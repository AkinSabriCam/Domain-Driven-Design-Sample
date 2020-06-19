using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise.EntityFramework.Migrations
{
    public partial class Updated_FieldName_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DleteTime",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DleteTime",
                table: "Buses");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Buses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Buses");

            migrationBuilder.AddColumn<DateTime>(
                name: "DleteTime",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DleteTime",
                table: "Buses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
