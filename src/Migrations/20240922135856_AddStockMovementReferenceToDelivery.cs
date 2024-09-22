using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace processo_seletivo_ultracar.Migrations
{
    /// <inheritdoc />
    public partial class AddStockMovementReferenceToDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockMovementId",
                table: "Deliveries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_StockMovementId",
                table: "Deliveries",
                column: "StockMovementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_StockMovements_StockMovementId",
                table: "Deliveries",
                column: "StockMovementId",
                principalTable: "StockMovements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_StockMovements_StockMovementId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_StockMovementId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "StockMovementId",
                table: "Deliveries");
        }
    }
}
