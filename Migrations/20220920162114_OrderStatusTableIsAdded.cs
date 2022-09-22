using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopMart.Migrations
{
    public partial class OrderStatusTableIsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderStatusId",
                table: "Tb_Orders",
                type: "int",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Tb_OrderStatus",
                columns: table => new
                {
                    orderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_OrderStatus", x => x.orderStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Orders_orderStatusId",
                table: "Tb_Orders",
                column: "orderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Orders_Tb_OrderStatus_orderStatusId",
                table: "Tb_Orders",
                column: "orderStatusId",
                principalTable: "Tb_OrderStatus",
                principalColumn: "orderStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Orders_Tb_OrderStatus_orderStatusId",
                table: "Tb_Orders");

            migrationBuilder.DropTable(
                name: "Tb_OrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Orders_orderStatusId",
                table: "Tb_Orders");

            migrationBuilder.DropColumn(
                name: "orderStatusId",
                table: "Tb_Orders");
        }
    }
}
