using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_received_product_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ReceivedProducts_RecievedProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RecievedProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReceivedProductId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "RecievedProductId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RecievedProductId",
                table: "Products",
                column: "RecievedProductId",
                unique: true,
                filter: "[RecievedProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ReceivedProducts_RecievedProductId",
                table: "Products",
                column: "RecievedProductId",
                principalTable: "ReceivedProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ReceivedProducts_RecievedProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RecievedProductId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "RecievedProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceivedProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_RecievedProductId",
                table: "Products",
                column: "RecievedProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ReceivedProducts_RecievedProductId",
                table: "Products",
                column: "RecievedProductId",
                principalTable: "ReceivedProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
