using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PryanikiTestTask.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PryanikiTestTask");

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "PryanikiTestTask",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "PryanikiTestTask",
                columns: table => new
                {
                    productId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "product_order",
                schema: "PryanikiTestTask",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "integer", nullable: false),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_order", x => new { x.orderId, x.productId });
                    table.ForeignKey(
                        name: "FK_product_order_orders_orderId",
                        column: x => x.orderId,
                        principalSchema: "PryanikiTestTask",
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_order_products_productId",
                        column: x => x.productId,
                        principalSchema: "PryanikiTestTask",
                        principalTable: "products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_order_productId",
                schema: "PryanikiTestTask",
                table: "product_order",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_order",
                schema: "PryanikiTestTask");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "PryanikiTestTask");

            migrationBuilder.DropTable(
                name: "products",
                schema: "PryanikiTestTask");
        }
    }
}
