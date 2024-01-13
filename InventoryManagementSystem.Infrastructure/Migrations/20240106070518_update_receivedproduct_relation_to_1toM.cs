using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_receivedproduct_relation_to_1toM : Migration
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
                name: "RecievedProductId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "RecievedProductId",
                table: "ReceivedProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedProducts_RecievedProductId",
                table: "ReceivedProducts",
                column: "RecievedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedProducts_Products_RecievedProductId",
                table: "ReceivedProducts",
                column: "RecievedProductId",
                principalTable: "Products",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedProducts_Products_RecievedProductId",
                table: "ReceivedProducts");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedProducts_RecievedProductId",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "RecievedProductId",
                table: "ReceivedProducts");

            migrationBuilder.AddColumn<int>(
                name: "RecievedProductId",
                table: "Products",
                type: "int",
                nullable: true);

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
    }
}
