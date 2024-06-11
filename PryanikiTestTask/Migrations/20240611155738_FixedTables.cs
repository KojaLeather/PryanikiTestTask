using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PryanikiTestTask.Migrations
{
    public partial class FixedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                schema: "PryanikiTestTask",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "sumPrice",
                schema: "PryanikiTestTask",
                table: "orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                schema: "PryanikiTestTask",
                table: "products");

            migrationBuilder.DropColumn(
                name: "sumPrice",
                schema: "PryanikiTestTask",
                table: "orders");
        }
    }
}
