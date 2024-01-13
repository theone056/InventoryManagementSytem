using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_database_relation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedProducts_Products_RecievedProductId",
                table: "ReceivedProducts");

            migrationBuilder.RenameColumn(
                name: "RecievedProductId",
                table: "ReceivedProducts",
                newName: "ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivedProducts_RecievedProductId",
                table: "ReceivedProducts",
                newName: "IX_ReceivedProducts_ProductCode");

            migrationBuilder.AddColumn<Guid>(
                name: "Code",
                table: "ReceivedProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedProducts_Products_ProductCode",
                table: "ReceivedProducts",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedProducts_Products_ProductCode",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ReceivedProducts");

            migrationBuilder.RenameColumn(
                name: "ProductCode",
                table: "ReceivedProducts",
                newName: "RecievedProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivedProducts_ProductCode",
                table: "ReceivedProducts",
                newName: "IX_ReceivedProducts_RecievedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedProducts_Products_RecievedProductId",
                table: "ReceivedProducts",
                column: "RecievedProductId",
                principalTable: "Products",
                principalColumn: "Code");
        }
    }
}
