using Microsoft.EntityFrameworkCore.Migrations;

namespace _98market.DataLayer.Migrations
{
    public partial class isactive_brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "brands",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "brands");
        }
    }
}
