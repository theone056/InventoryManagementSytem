using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_database_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ReceivedProducts");

            migrationBuilder.AddColumn<int>(
                name: "ReceivedProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecievedProductId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RecievedProductId",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "ReceivedProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCode",
                table: "ReceivedProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ReceivedProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ReceivedProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
