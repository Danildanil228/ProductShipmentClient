using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductShipmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddShipmentReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Shipments",
                newName: "BatchCost");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Shipments",
                newName: "BatchSize");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BatchSize",
                table: "Shipments",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "BatchCost",
                table: "Shipments",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");
        }
    }
}
