using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ECommerceNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Apple Watch Series 1, temel sağlık ve bildirim takibi özelliklerine sahip, spor ve günlük kullanım odaklı bir akıllı saattir.", "Apple Watch Series 1", 7000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Apple Watch Series 2, daha hızlı bir işlemci ve gelişmiş sağlık izleme özellikleri sunan bir akıllı saattir.", "Apple Watch Series 2", 15000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Apple Watch Series 3, suya dayanıklılık ve gelişmiş fitness özellikleri ile donatılmış bir akıllı saattir.", "Apple Watch Series 3", 20000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Xiaomi Redmi Watch 1, uygun fiyatlı bir akıllı saat arayanlar için ideal bir seçenektir.", "Xiaomi Redmi Watch 1", 3500m, 150 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 5, "Xiaomi Redmi Watch 2, daha büyük bir ekran ve geliştirilmiş sağlık izleme özellikleri sunan bir akıllı saattir.", null, true, "Xiaomi Redmi Watch 2", 5000m, 150 },
                    { 6, "Xiaomi Redmi Watch 3, daha fazla özellik ve şıklık sunan bir akıllı saattir.", null, true, "Xiaomi Redmi Watch 3", 6000m, 200 },
                    { 7, "Xiaomi Redmi Watch 4, daha fazla özelliği uygun fiyatlı bir akıllı saatte arayanlar için ideal bir seçenektir.", null, true, "Xiaomi Redmi Watch 4", 3500m, 400 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Telefon Açıklaması", "Iphone 15", 10.0m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Telefon Açıklaması 2", "Iphone 16", 20.0m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Telefon Açıklaması 3", "Iphone 16 Pro", 30.0m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Telefon Açıklaması 4", "Iphone 16 Pro Max", 40.0m, 400 });
        }
    }
}
