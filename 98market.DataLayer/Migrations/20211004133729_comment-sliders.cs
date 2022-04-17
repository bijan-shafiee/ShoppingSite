using Microsoft.EntityFrameworkCore.Migrations;

namespace _98market.DataLayer.Migrations
{
    public partial class commentsliders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Abilities",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Appearance",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuyWorth",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EaseOfUse",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Innovation",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quality",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abilities",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Appearance",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "BuyWorth",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "EaseOfUse",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Innovation",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Quality",
                table: "comments");
        }
    }
}
