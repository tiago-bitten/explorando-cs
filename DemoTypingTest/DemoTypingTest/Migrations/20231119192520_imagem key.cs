using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoTypingTest.Migrations
{
    public partial class imagemkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profile_image_url",
                table: "AspNetUsers",
                newName: "profile_image_key");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profile_image_key",
                table: "AspNetUsers",
                newName: "profile_image_url");
        }
    }
}
