using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class minor_fixed_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedProducts_Products_ProductCode",
                table: "ReceivedProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductCode",
                table: "ReceivedProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedProducts_Products_ProductCode",
                table: "ReceivedProducts",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedProducts_Products_ProductCode",
                table: "ReceivedProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductCode",
                table: "ReceivedProducts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedProducts_Products_ProductCode",
                table: "ReceivedProducts",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code");
        }
    }
}
