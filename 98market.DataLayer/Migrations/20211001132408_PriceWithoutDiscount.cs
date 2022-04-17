using Microsoft.EntityFrameworkCore.Migrations;

namespace _98market.DataLayer.Migrations
{
    public partial class PriceWithoutDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PriceWithoutDiscount",
                table: "CartDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceWithoutDiscount",
                table: "CartDetail");
        }
    }
}
