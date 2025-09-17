using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
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

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Name", "Description", "Price", "IsActive", "ImageUrl", "Stock" },
				values: new object[] { 1, "Apple Watch Series 1", "Apple Watch Series 1, temel sağlık ve bildirim takibi özelliklerine sahip, spor ve günlük kullanım odaklı bir akıllı saattir.", 7000m, true, null, 100 });

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Name", "Description", "Price", "IsActive", "ImageUrl", "Stock" },
				values: new object[] { 2, "Apple Watch Series 2", "Apple Watch Series 2, daha hızlı bir işlemci ve gelişmiş sağlık izleme özellikleri sunan bir akıllı saattir.", 15000m, true, null, 200 });

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Name", "Description", "Price", "IsActive", "ImageUrl", "Stock" },
				values: new object[] { 3, "Apple Watch Series 3", "Apple Watch Series 3, suya dayanıklılık ve gelişmiş fitness özellikleri ile donatılmış bir akıllı saattir.", 20000m, true, null, 300 });

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Name", "Description", "Price", "IsActive", "ImageUrl", "Stock" },
				values: new object[] { 4, "Xiaomi Redmi Watch 1", "Xiaomi Redmi Watch 1, uygun fiyatlı bir akıllı saat arayanlar için ideal bir seçenektir.", 3500m, true, null, 150 });

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Name", "Description", "Price", "IsActive", "ImageUrl", "Stock" },
				values: new object[] { 5, "Xiaomi Redmi Watch 2", "Xiaomi Redmi Watch 2, daha büyük bir ekran ve geliştirilmiş sağlık izleme özellikleri sunan bir akıllı saattir.", 5000m, true, null, 150 });

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Name", "Description", "Price", "IsActive", "ImageUrl", "Stock" },
				values: new object[] { 6, "Xiaomi Redmi Watch 3", "Xiaomi Redmi Watch 3, daha fazla özellik ve şıklık sunan bir akıllı saattir.", 6000m, true, null, 200 });

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Name", "Description", "Price", "IsActive", "ImageUrl", "Stock" },
				values: new object[] { 7, "Xiaomi Redmi Watch 4", "Xiaomi Redmi Watch 4, daha fazla özelliği uygun fiyatlı bir akıllı saatte arayanlar için ideal bir seçenektir.", 3500m, true, null, 400 });

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
						onDelete: ReferentialAction.Restrict);
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
