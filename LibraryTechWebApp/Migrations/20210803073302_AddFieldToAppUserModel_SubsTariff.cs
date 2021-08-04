using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryTechWebApp.Migrations
{
    public partial class AddFieldToAppUserModel_SubsTariff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubsTariff",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubsTariff",
                table: "AspNetUsers");
        }
    }
}
