using Microsoft.EntityFrameworkCore.Migrations;

namespace _98market.DataLayer.Migrations
{
    public partial class cart_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "posted",
                table: "cart");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrackingCode",
                table: "cart",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "TrackingCode",
                table: "cart");

            migrationBuilder.AddColumn<bool>(
                name: "posted",
                table: "cart",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
