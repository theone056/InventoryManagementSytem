using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSalesClassDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Sales");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductCode",
                table: "Sales",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductCode",
                table: "Sales",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductCode",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ProductCode",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SellingPrice",
                table: "Sales",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
