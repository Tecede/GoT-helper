using Microsoft.EntityFrameworkCore.Migrations;

namespace npcGenerator.Migrations
{
    public partial class fourmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeroImgPath",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroImgPath",
                table: "Characters");
        }
    }
}
