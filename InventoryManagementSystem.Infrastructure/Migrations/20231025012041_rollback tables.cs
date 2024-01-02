using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rollbacktables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedProducts_Products_ProductCode",
                table: "ReceivedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductCode",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductCode",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductCode",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ProductCode",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedProducts_ProductCode",
                table: "ReceivedProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductCode",
                table: "Stocks",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductCode",
                table: "Sales",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedProducts_ProductCode",
                table: "ReceivedProducts",
                column: "ProductCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedProducts_Products_ProductCode",
                table: "ReceivedProducts",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductCode",
                table: "Sales",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductCode",
                table: "Stocks",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
