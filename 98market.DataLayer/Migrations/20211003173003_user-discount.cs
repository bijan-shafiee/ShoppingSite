using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _98market.DataLayer.Migrations
{
    public partial class userdiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "UserDiscounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "UserDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MinPrice",
                table: "discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinalPrice",
                table: "cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscounts_CartId",
                table: "UserDiscounts",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiscounts_cart_CartId",
                table: "UserDiscounts",
                column: "CartId",
                principalTable: "cart",
                principalColumn: "cartid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDiscounts_cart_CartId",
                table: "UserDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_UserDiscounts_CartId",
                table: "UserDiscounts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "UserDiscounts");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "UserDiscounts");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "discounts");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "cart");
        }
    }
}
