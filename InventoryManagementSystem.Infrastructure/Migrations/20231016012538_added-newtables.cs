using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addednewtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    EncodedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    TotalSales = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedQty = table.Column<double>(type: "float", nullable: false),
                    SalesQty = table.Column<double>(type: "float", nullable: false),
                    StockQty = table.Column<double>(type: "float", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    TotalSales = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ReceivedProducts");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
