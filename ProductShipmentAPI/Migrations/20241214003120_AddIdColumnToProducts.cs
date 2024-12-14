using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductShipmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIdColumnToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Товар1", 100m },
                    { 2, "Товар2", 200m },
                    { 3, "Товар3", 300m }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "ShipmentId", "ProductId", "Quantity", "ShipmentDate", "Store", "TotalCost" },
                values: new object[,]
                {
                    { 1, 1, 50, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "name1", 5000m },
                    { 2, 1, 30, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "name2", 6000m },
                    { 3, 1, 20, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "name3", 6000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");
        }
    }
}
