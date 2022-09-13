using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopMart.Migrations
{
    public partial class orderingTablesAreAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Payement",
                columns: table => new
                {
                    payementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payementType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Payement", x => x.payementId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_ShippingInfo",
                columns: table => new
                {
                    shippingInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_ShippingInfo", x => x.shippingInfoId);
                    table.ForeignKey(
                        name: "FK_Tb_ShippingInfo_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payementId = table.Column<int>(type: "int", nullable: false),
                    shippingInfoId = table.Column<int>(type: "int", nullable: false),
                    totalOrderQty = table.Column<int>(type: "int", nullable: false),
                    totalOrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Tb_Orders_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Orders_Tb_Payement_payementId",
                        column: x => x.payementId,
                        principalTable: "Tb_Payement",
                        principalColumn: "payementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Orders_Tb_ShippingInfo_shippingInfoId",
                        column: x => x.shippingInfoId,
                        principalTable: "Tb_ShippingInfo",
                        principalColumn: "shippingInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_OrderItem",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalQty = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_OrderItem", x => new { x.orderId, x.itemId });
                    table.ForeignKey(
                        name: "FK_Tb_OrderItem_Tb_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Tb_Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_OrderItem_TbItems_itemId",
                        column: x => x.itemId,
                        principalTable: "TbItems",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_OrderItem_itemId",
                table: "Tb_OrderItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Orders_payementId",
                table: "Tb_Orders",
                column: "payementId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Orders_shippingInfoId",
                table: "Tb_Orders",
                column: "shippingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Orders_userId",
                table: "Tb_Orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_ShippingInfo_userId",
                table: "Tb_ShippingInfo",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_OrderItem");

            migrationBuilder.DropTable(
                name: "Tb_Orders");

            migrationBuilder.DropTable(
                name: "Tb_Payement");

            migrationBuilder.DropTable(
                name: "Tb_ShippingInfo");
        }
    }
}
