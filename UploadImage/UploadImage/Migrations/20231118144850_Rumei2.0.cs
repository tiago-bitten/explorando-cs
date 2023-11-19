using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UploadImage.Migrations
{
    public partial class Rumei20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product",
                table: "tb_product_images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "tb_product_images",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
