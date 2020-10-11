using Microsoft.EntityFrameworkCore.Migrations;

namespace npcGenerator.Migrations
{
    public partial class NePomnuChtoDobavil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Beard",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cloth",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hair",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HairColor",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interaction",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manners",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quest",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Richness",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Beard",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Cloth",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Hair",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HairColor",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Interaction",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Manners",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Quest",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Richness",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Sign",
                table: "Characters");
        }
    }
}
