using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class migr3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Season",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Season_ProductId",
                table: "Season",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderId1",
                table: "Order",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Order_OrderId1",
                table: "Order",
                column: "OrderId1",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Product_ProductId",
                table: "Season",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Order_OrderId1",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Product_ProductId",
                table: "Season");

            migrationBuilder.DropIndex(
                name: "IX_Season_ProductId",
                table: "Season");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderId1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Order");
        }
    }
}
