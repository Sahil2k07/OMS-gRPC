using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oms_core.Migrations
{
    /// <inheritdoc />
    public partial class OrderEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    ID = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryIdentifier = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.ID);
                }
            );

            migrationBuilder.CreateTable(
                name: "ORDER_ITEM",
                columns: table => new
                {
                    ID = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrimaryIdentifier = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_ORDER_OrderID",
                        column: x => x.OrderID,
                        principalTable: "ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_OrderID",
                table: "ORDER_ITEM",
                column: "OrderID"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ORDER_ITEM");

            migrationBuilder.DropTable(name: "ORDER");
        }
    }
}
