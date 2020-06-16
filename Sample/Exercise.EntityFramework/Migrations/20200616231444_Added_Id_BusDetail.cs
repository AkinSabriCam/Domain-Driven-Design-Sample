using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise.EntityFramework.Migrations
{
    public partial class Added_Id_BusDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusDetailId",
                table: "BusDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BusDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "BusDetails");

            migrationBuilder.AddColumn<int>(
                name: "BusDetailId",
                table: "BusDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
