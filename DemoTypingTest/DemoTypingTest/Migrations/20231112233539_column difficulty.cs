using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoTypingTest.Migrations
{
    public partial class columndifficulty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "difficulty",
                table: "tb_test",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "difficulty",
                table: "tb_test");
        }
    }
}
