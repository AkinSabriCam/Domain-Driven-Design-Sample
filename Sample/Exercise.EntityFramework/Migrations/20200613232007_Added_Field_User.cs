using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise.EntityFramework.Migrations
{
    public partial class Added_Field_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomField",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomField",
                table: "AspNetUsers");
        }
    }
}
