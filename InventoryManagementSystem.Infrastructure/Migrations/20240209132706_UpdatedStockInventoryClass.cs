using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStockInventoryClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Stocks");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductCode",
                table: "Stocks",
                column: "ProductCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductCode",
                table: "Stocks",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductCode",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductCode",
                table: "Stocks");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SellingPrice",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
