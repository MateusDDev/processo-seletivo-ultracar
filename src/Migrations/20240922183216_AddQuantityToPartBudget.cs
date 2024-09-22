using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace processo_seletivo_ultracar.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityToPartBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartQuantity",
                table: "PartBudgets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartQuantity",
                table: "PartBudgets");
        }
    }
}
