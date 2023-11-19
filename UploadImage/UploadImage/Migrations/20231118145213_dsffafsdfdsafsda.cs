using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UploadImage.Migrations
{
    public partial class dsffafsdfdsafsda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_1",
                table: "tb_product_images");

            migrationBuilder.DropColumn(
                name: "image_2",
                table: "tb_product_images");

            migrationBuilder.RenameColumn(
                name: "image_4",
                table: "tb_product_images",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "image_3",
                table: "tb_product_images",
                newName: "key");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "tb_product_images",
                newName: "image_4");

            migrationBuilder.RenameColumn(
                name: "key",
                table: "tb_product_images",
                newName: "image_3");

            migrationBuilder.AddColumn<string>(
                name: "image_1",
                table: "tb_product_images",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image_2",
                table: "tb_product_images",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
