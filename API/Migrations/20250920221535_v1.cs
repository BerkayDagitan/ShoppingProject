using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Apple Watch Series 1, temel sağlık ve bildirim takibi özelliklerine sahip, spor ve günlük kullanım odaklı bir akıllı saattir.", "1.jpg", true, "Apple Watch Series 1", 7000m, 100 },
                    { 2, "Apple Watch Series 2, daha hızlı bir işlemci ve gelişmiş sağlık izleme özellikleri sunan bir akıllı saattir.", "2.jpg", true, "Apple Watch Series 2", 15000m, 200 },
                    { 3, "Apple Watch Series 3, suya dayanıklılık ve gelişmiş fitness özellikleri ile donatılmış bir akıllı saattir.", "3.jpg", true, "Apple Watch Series 3", 20000m, 300 },
                    { 4, "Xiaomi Redmi Watch 1, uygun fiyatlı bir akıllı saat arayanlar için ideal bir seçenektir.", "4.jpg", true, "Xiaomi Redmi Watch 1", 3500m, 150 },
                    { 5, "Xiaomi Redmi Watch 2, daha büyük bir ekran ve geliştirilmiş sağlık izleme özellikleri sunan bir akıllı saattir.", "5.jpg", true, "Xiaomi Redmi Watch 2", 5000m, 150 },
                    { 6, "Xiaomi Redmi Watch 3, daha fazla özellik ve şıklık sunan bir akıllı saattir.", "6.jpg", true, "Xiaomi Redmi Watch 3", 6000m, 200 },
                    { 7, "Xiaomi Redmi Watch 4, daha fazla özelliği uygun fiyatlı bir akıllı saatte arayanlar için ideal bir seçenektir.", "7.jpg", true, "Xiaomi Redmi Watch 4", 3500m, 400 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
