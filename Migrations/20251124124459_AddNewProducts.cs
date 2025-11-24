using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberShop.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 3, "Giữ nếp tóc lâu dài, tự nhiên.", "/img/hairspray.png", "Gôm Xịt Tóc", 180000m, 40 },
                    { 4, "Bọt mịn, giúp cạo râu dễ dàng và bảo vệ da.", "/img/shaving_cream.png", "Kem Cạo Râu", 120000m, 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
