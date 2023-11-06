using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoTypingTest.Migrations
{
    public partial class TableTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_test",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    text_test = table.Column<string>(type: "text", nullable: false),
                    total_words = table.Column<int>(type: "integer", nullable: false),
                    total_characters = table.Column<int>(type: "integer", nullable: false),
                    incorrect_words = table.Column<int>(type: "integer", nullable: false),
                    incorrect_characters = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_test", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_test_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_test_user_id",
                table: "tb_test",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_test");
        }
    }
}
