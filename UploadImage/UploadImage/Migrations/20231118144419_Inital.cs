using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UploadImage.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_product",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    purchase_price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_product_images",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    image_1 = table.Column<string>(type: "text", nullable: false),
                    image_2 = table.Column<string>(type: "text", nullable: false),
                    image_3 = table.Column<string>(type: "text", nullable: false),
                    image_4 = table.Column<string>(type: "text", nullable: false),
                    product_id = table.Column<string>(type: "text", nullable: false),
                    Product = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_product_images_tb_product_product_id",
                        column: x => x.product_id,
                        principalTable: "tb_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_images_product_id",
                table: "tb_product_images",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_product_images");

            migrationBuilder.DropTable(
                name: "tb_product");
        }
    }
}
