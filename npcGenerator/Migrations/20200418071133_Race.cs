using Microsoft.EntityFrameworkCore.Migrations;

namespace npcGenerator.Migrations
{
    public partial class Race : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Clan",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Knowledge",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clan",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Knowledge",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Characters");
        }
    }
}
